
namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Controllers
            builder.Services.AddControllers();

            // Add swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            builder.Services.AddAuthorization();

            //// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            // Register the Inventory gRPC Client
            builder.Services.AddGrpcClient<Inventory.Service.Protos.Inventory.InventoryClient>(options =>
            {
                options.Address = new Uri("https://localhost:7016");
            });

            // Register the Payment gRPC Client
            builder.Services.AddGrpcClient<Payment.Service.Protos.Payment.PaymentClient>(options =>
            {
                options.Address = new Uri("https://localhost:7230");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                // Enable Swagger Middlewares
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Map the controllers to the endpoints
            app.MapControllers();

            app.Run();
        }
    }
}
