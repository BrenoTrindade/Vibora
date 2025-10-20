using Microsoft.EntityFrameworkCore;
using Vibora.Application.Common.Interfaces;
using Vibora.Application.Users.Commands;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;
using Vibora.Infrastructure.Repositories;
using Vibora.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));

var connectionString = builder.Configuration.GetConnectionString("ViboraDb");
builder.Services.AddDbContext<ViboraDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
