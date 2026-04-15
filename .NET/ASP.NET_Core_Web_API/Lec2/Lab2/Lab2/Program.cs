
using Lab2.MappingProfiles;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register the ITIContext with the Dependency Injection container
            builder.Services.AddDbContext<ITIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper and scan the current assembly for mapping profiles
            builder.Services.AddAutoMapper(op => op.AddProfile<MappConfig>());

            // 1. Define the CORS Policy
            string corsPolicyName = "MyAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin() // Allows requests from any domain
                              .AllowAnyMethod() // Allows any HTTP method (GET, POST, PUT, DELETE)
                              .AllowAnyHeader(); // Allows any HTTP headers
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            // 2. Enable the CORS middleware
            // CRITICAL: UseCors must be placed between UseRouting and UseAuthorization
            app.UseCors(corsPolicyName);

            app.MapControllers();

            app.Run();
        }
    }
}
