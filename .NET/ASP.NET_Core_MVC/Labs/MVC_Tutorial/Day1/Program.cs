using ITIEntities;
using ITIEntities.Data;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(s =>
                {
                    s.LoginPath = "/Account/Login";    // put your login-action path
                    // Redirect users who don't have the required role (e.g., a Student trying to open Admin pages)
                    s.AccessDeniedPath = "/Account/Login"; // Or create a specific "/Home/AccessDenied" view later
                });
            // Add services to the Dependency Injection Container
            builder.Services.AddScoped<IEntityRepo<Department>, DepartmentRepo>();
            builder.Services.AddScoped<IEntityRepo<Student>, StudentRepo>();
            builder.Services.AddScoped<IEntityRepo<Course>, CourseRepo>();
            builder.Services.AddScoped<IEntityRepo<StudentCourse>, StudentCourseRepo>();
            builder.Services.AddScoped<IEntityRepo<User>, UserRepo>();
            builder.Services.AddDbContext<ITIContext>(s =>
            {
                s.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
