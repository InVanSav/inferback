using Inferback.DAL;
using Inferback.DAL.Interfaces;
using Inferback.DAL.Repositories;
using Inferback.Service.Implementations;
using Inferback.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.
    GetConnectionString("DefaultConnection");
builder.Services.
    AddDbContext<ApplicationDbContext>
        (options => options.UseMySql(
                                     connection,
                                     new MariaDbServerVersion(new Version(10, 9, 5))
                                    )
        );

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IReportService, ReportService>();

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