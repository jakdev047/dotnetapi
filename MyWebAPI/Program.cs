using Microsoft.EntityFrameworkCore;
using MyWebAPI.Context;
using MyWebAPI.Interfaces.Manager;
using MyWebAPI.Manager;

// builder craete
var builder = WebApplication.CreateBuilder(args);

// database access
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

// dependency injection
builder.Services.AddTransient<IPostManager, PostManager>(); // 1 object create
// builder.Services.AddScoped<IPostManager, PostManager>(); // scope wise object create
// builder.Services.AddSingleton<IPostManager, PostManager>(); // whole application 1 object create

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
