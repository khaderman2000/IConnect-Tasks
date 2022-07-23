
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WebApplication2.Repo.UserRepo,WebApplication2.Repo.UserRepo>();
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("UserDB"));
var app = builder.Build();
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
   // app.Us eSwagger();
  //  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//
app.UseAuthorization();

app.MapControllers();

app.Run();
