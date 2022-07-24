using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<PostContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserService ,UserService>();
builder.Services.AddScoped<IPostService ,PostService>();

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
