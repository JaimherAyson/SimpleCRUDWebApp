using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using SimpleCRUDWebApp.Server.Data;
using SimpleCRUDWebApp.Server.Services.Contracts;
using static SimpleCRUDWebApp.Server.Services.StudentServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


builder.Services.AddDbContext<StudentDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI as the root page
    });
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
