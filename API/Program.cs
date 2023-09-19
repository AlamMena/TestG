
using API.DbModels;
using API.Services;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAlgorithmsService, AlgorithmService>();
builder.Services.AddScoped<ILogginService, LogginService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebCors",
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithMethods("*");
            builder.WithOrigins("*");
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseCors("WebCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


