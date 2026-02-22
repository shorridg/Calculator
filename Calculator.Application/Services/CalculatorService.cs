using Microsoft.Extensions.Logging;
using Calculator.Application.Interfaces;
using Calculator.Application.Models;

namespace Calculator.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger) { 
            _logger = logger;
        }

        public CalculationResponse Add(CalculationRequest request) {
            _logger.LogInformation("Adding {X} and {Y}", request.X, request.Y);
            return new CalculationResponse { Result = (request.X + request.Y) };
        }

        public CalculationResponse Subtract(CalculationRequest request)
        {
            _logger.LogInformation("Subtracting {Y} from {X}", request.X, request.Y);
            return new CalculationResponse { Result = (request.X - request.Y) };
        }

        public CalculationResponse Multiply(CalculationRequest request) {
            _logger.LogInformation("Multiplying {X} and {Y}", request.X, request.Y);
            return new CalculationResponse { Result = (request.X * request.Y) };
        }

        public CalculationResponse Divide(CalculationRequest request) {
            if (request.Y == 0)
            {
                _logger.LogWarning("Attempted division by zero: {X} / {Y}", request.X, request.Y);
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            _logger.LogInformation("Dividing {X} by {Y}", request.X, request.Y);
            return new CalculationResponse { Result = (request.X / request.Y) };
        }
    }
}
