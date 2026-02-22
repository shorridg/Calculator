using Calculator.Infrastructure;
using Calculator.Infrastructure.Entities;

namespace Calculator.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, LoggingContext db)
        {
            context.Request.EnableBuffering();

            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            var log = new LogEntry
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                Body = body,
                Timestamp = DateTime.UtcNow
            };

            db.Logs.Add(log);
            await db.SaveChangesAsync();

            await _next(context);
        }
    }
}

