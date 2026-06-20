
using Carter;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TangyAPI.Data;
using TangyAPI.DTOs;
using TangyAPI.Models;

namespace TangyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
            );
            builder.Services.AddCarter();
            builder.Services.AddOpenApi();
            builder.Services.AddValidation();
            builder.Services.AddProblemDetails();

            builder.Services.AddAutoMapper(config =>
            {
                config.CreateMap<Category, CategoryDto>().ReverseMap();
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.MapCarter();

            app.Run();
        }
    }
}
