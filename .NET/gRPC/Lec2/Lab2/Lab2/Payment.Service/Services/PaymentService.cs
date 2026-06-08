using Grpc.Core;
using Payment.Service.Models;
using Payment.Service.Protos;

namespace Payment.Service.Services
{
    public class PaymentService(ILogger<PaymentService> logger) : Protos.Payment.PaymentBase
    {
        // List of users with their balances
        private static List<User> users = new List<User>
        {
            new User{UserId = 1, Balance = 1000},
            new User{UserId = 2, Balance = 2000},
            new User{UserId = 3, Balance = 3000}
        };

        public override Task<PaymentResponse> DeductBalance(PaymentRequest request, ServerCallContext context)
        {
            // Find user
            var user = users.FirstOrDefault(u => u.UserId == request.UserId);
            if(user == null)
            {
                logger.LogWarning("User with ID {UserId} was not found.", request.UserId);

                throw new RpcException(new Status(StatusCode.NotFound, $"User with ID {request.UserId} does not exist."));
            }

            if(user.Balance < request.OrderPrice)
            {
                logger.LogWarning($"Insufficient balance for UserId {user.UserId}.");

                return Task.FromResult(new PaymentResponse
                {
                    IsSuccess = false,
                    Message = $"Failed: User balance is insufficient."
                });
            }

            // Success Payment
            user.Balance -= request.OrderPrice;
            logger.LogInformation("Balance deducted successfully.");

            return Task.FromResult(new PaymentResponse
            {
                IsSuccess = true,
                Message = $"Success: Deducted balance is {request.OrderPrice}."
            });
        }
    }
}
