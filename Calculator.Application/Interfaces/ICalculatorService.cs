using Calculator.Application.Models;

namespace Calculator.Application.Interfaces
{
    public interface ICalculatorService
    {
        CalculationResponse Add(CalculationRequest request);
        CalculationResponse Subtract(CalculationRequest request);
        CalculationResponse Multiply(CalculationRequest request);
        CalculationResponse Divide(CalculationRequest request);
    }
}
