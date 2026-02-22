using Calculator.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Infrastructure
{
    public class LoggingContext: DbContext
    {
        public LoggingContext(DbContextOptions<LoggingContext> options) : base(options) {}
        public DbSet<LogEntry> Logs => Set<LogEntry>();
    }
}
