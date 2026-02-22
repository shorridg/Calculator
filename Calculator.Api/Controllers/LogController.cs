using Calculator.Infrastructure;
using Calculator.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Controllers
{
    public class LogController : Controller
    {
        [HttpGet("logs")]
        public IEnumerable<LogEntry> GetLogs([FromServices] LoggingContext db)
        {
            return db.Logs.OrderByDescending(x=>x.Timestamp).ToList();
        }
    }
}
