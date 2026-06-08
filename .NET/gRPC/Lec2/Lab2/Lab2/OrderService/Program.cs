
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

            // Add standard gRPC services
            builder.Services.AddGrpc();

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

            //Add CORS Policy for gRPC-Web
            builder.Services.AddCors(o => o.AddPolicy("AllowFrontend", builder =>
            {
                // Allow requests from the fontend app running on this origin
                builder.WithOrigins("http://127.0.0.1:5500")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       // Expose standard gRPC headers so the JS client can read the responses
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();

                // Enable Swagger Middlewares
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS &gRPC-Web Middleware
            app.UseCors("AllowFrontend");   // Must be placed before UseGrpcWeb and UseAuthorization

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            app.UseAuthorization();

            // Map the controllers to the endpoints
            app.MapControllers();

            // Map the new OrderService and enable gRPC-Web
            app.MapGrpcService<Services.OrderService>()
                .EnableGrpcWeb();

            app.Run();
        }
    }
}
