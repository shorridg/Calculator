using Calculator.Application.Models;
using Calculator.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Calculator.Application.Tests.Services;
public class CalculatorServiceTests
{
    private readonly CalculatorService _service;

    public CalculatorServiceTests()
    {
        var logger = new Mock<ILogger<CalculatorService>>();
        _service = new CalculatorService(logger.Object);
    }

    [Fact]
    public void Add_ReturnsCorrectResult()
    {
        // Arrange
        var request = new CalculationRequest { X = 26, Y = 13 };

        // Act
        var result = _service.Add(request);

        // Assert
        Assert.Equal(39, result.Result);
    }

    [Fact]
    public void Divide_ThrowsDivideByZeroErrorIfYIsZero()
    {
        // Arrange
        var request = new CalculationRequest { X = 7, Y = 0 };

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _service.Divide(request));
    }
}
