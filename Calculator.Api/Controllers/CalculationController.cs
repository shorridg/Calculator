using Calculator.Application.Interfaces;
using Calculator.Application.Models;
using Calculator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

using Calculator.Infrastructure.Entities;

namespace Calculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculationController(ICalculatorService calculationService)
        {
            _calculatorService = calculationService;
        }

        [HttpPost("add")]
        public ActionResult<CalculationResponse> Add([FromBody] CalculationRequest request)
        {
            var response = _calculatorService.Add(request);
            return Ok(response);
        }
        
        [HttpPost("subtract")]
        public ActionResult<CalculationResponse> Subtract([FromBody] CalculationRequest request)
        {
            var response = _calculatorService.Subtract(request);
            return Ok(response);
        }

        [HttpPost("multiply")]
        public ActionResult<CalculationResponse> Multiply([FromBody] CalculationRequest request)
        {
            var response = _calculatorService.Multiply(request);
            return Ok(response);
        }

        [HttpPost("divide")]
        public ActionResult<CalculationResponse> Divide([FromBody] CalculationRequest request)
        {
            try
            {
                var response = _calculatorService.Divide(request);
                return Ok(response);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
