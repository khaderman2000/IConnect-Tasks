using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using UserUsingFrameWork.Extensions;
using UserUsingFrameWork.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Start(builder.Configuration);

var app = builder.Build();
app.UseHandle();
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
