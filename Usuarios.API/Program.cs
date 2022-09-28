using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Models;
using Usuarios.Services.Interfaces;
using Usuarios.Services.Concrete;
using Usuarios.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(opts =>
    opts
       .UseMySql(
            builder
                .Configuration
                .GetConnectionString("UsuarioConnection"),
                new MySqlServerVersion(new Version(8, 0))
            ));
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>(
    /*opts => opts.SignIn.RequireConfirmedEmail = true*/
    )
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();
builder.Host.ConfigureAppConfiguration((context, builder) => builder.AddUserSecrets<Program>());
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILogoutService, LogoutService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
