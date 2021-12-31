using System.Reflection;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Middlewares;
using BookstoreWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookstoreDbContext>(options => options.UseInMemoryDatabase("BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLoggerService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// custom
app.UseCustomExceptionMiddleware();

app.Run();
