using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.BLL;
using WebAPI.BLL.Interfaces;
using WebAPI.DAL;
using WebAPI.DAL.Interfaces;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<Database>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserBll, UserBll>();
builder.Services.AddScoped<ICountryBll, CountryBll>();
builder.Services.AddScoped<ICelebritieBll, CelebritieBll>();
builder.Services.AddScoped<IAuthorizationBll, AuthorizationBll>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(opt => 
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:1234",
        ValidAudience = "http://localhost:1234",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey@$%2123"))
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .Build();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("mypolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
