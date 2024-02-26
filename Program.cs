using Microsoft.EntityFrameworkCore;
using SportsBookings.DbModels;
using SportsBookings.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DBConn");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRegistrationManager, RegistrationManager>();
builder.Services.AddScoped<ISessionManager, SessionManager>();

var app = builder.Build();

// Configure CORS
app.UseCors(builder => builder
    .WithOrigins("http://localhost:8100") // Update with the origin of your frontend application
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()); // Allow credentials if your frontend application sends cookies or other credentials

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
