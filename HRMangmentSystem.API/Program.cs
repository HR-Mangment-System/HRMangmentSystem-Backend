using HRMangmentSystem.API.Mapping;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.BusinessLayer.Repository;
using HRMangmentSystem.DataAccessLayer.Context;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
builder.Services.AddDbContext<HRMangmentCotext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("abdelwahabConn")));

//auto mapper dependency injection
builder.Services.AddAutoMapper(typeof(AccountPostMapping)); // Add AutoMapper services

// Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HRMangmentCotext>()
    .AddDefaultTokenProviders();
//Injecting Business Layer Dependencies
//builder.Services.BusinessLayerModuleDependendcies();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();


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
