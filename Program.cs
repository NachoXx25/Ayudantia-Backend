using ayudantia.src.Data;
using dotenv.net;
using dotenv.net.Utilities;
using Microsoft.EntityFrameworkCore;


DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => 
    options.UseNpgsql(EnvReader.GetStringValue("PostgreSQLConnection")));



// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();   
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

