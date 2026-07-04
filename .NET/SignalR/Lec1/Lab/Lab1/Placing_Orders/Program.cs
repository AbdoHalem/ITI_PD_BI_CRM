using Placing_Orders.Hubs;

namespace Placing_Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSignalR();  // Add SignalR services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapHub<OrderHub>("/orderHub");  // Map the SignalR hub

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Order}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
