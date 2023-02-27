using inferback.DAL;
using inferback.DAL.Interfaces;
using inferback.DAL.Repositories;
using inferback.Service.Implementations;
using inferback.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>
(options => options.UseMySql(
        connection,
        new MariaDbServerVersion(new Version(10, 9, 5))
    )
);

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();
builder.Services.AddTransient<IDescriptionRepository, DescriptionRepository>();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IDescriptionService, DescriptionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
