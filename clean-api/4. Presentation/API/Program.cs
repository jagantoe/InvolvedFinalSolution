using Business.Configuration;
using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterTodoApplicationServices();

if (builder.Environment.IsDevelopment())
    builder.Services.RegisterSqliteDataAccessServices(builder.Configuration);
else
    builder.Services.RegisterSqlServerDataAccessServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<TodoDbContext>();
    if (builder.Environment.IsDevelopment())
        context.Database.EnsureCreated(); // Creates the database if it doesn't exist
    context.Database.Migrate();
}

app.Run();