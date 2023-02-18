using Inferback.DAL;
using Inferback.DAL.Interfaces;
using Inferback.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.
    GetConnectionString("DefaultConnection");
builder.Services.
    AddDbContext<ApplicationDbContext>(options => 
                                           options.UseSqlServer(connection));

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();

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