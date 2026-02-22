using Calculator.Api.Middleware;
using Calculator.Application.Interfaces;
using Calculator.Application.Services;
using Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

// SqlLite
builder.Services.AddDbContext<LoggingContext>(options =>
    options.UseSqlite("Data Source=logging.db"));

var app = builder.Build();

// Create db
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LoggingContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Middleware for logging requests to db
app.UseMiddleware<RequestLoggingMiddleware>();

// Middleware for checking api key
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
