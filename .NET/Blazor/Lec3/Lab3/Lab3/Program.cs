using Lab3.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Lab3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // 1. Configure the HttpClient
            // IMPORTANT: Change the port to match the actual port your Web API is running on!
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7259/") });

            // 2. Register our custom services (Dependency Inversion)
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            await builder.Build().RunAsync();
        }
    }
}
