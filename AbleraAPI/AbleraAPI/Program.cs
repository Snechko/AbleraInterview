using Microsoft.EntityFrameworkCore;
using AbleraAPI.Data;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<CarsAPIDbContext>(options => options.UseInMemoryDatabase("carsDB"));
builder.Services.AddDbContext<CarsAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ableraConnectionString")));


/////////////////////////////////////////////////////
//
//  TO SET UP DATABASE TABLE RUN:
//
//  "Update-Database"
//
//   COMMAND IN THE PACKAGE MANAGER CONSOLE
//
/////////////////////////////////////////////////////
//
//  TO CHANGE DATABASE LOCATION CHANGE:
//
//  "ableraConnectionString"
//
//  IN appsettings.json WITH THE DESIRED IP
//
/////////////////////////////////////////////////////


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
