using BloggingPlatformApi.Models;
using BloggingPlatformApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configurations
builder.Services.Configure<BloggingPlatformDatabaseSettings>(builder.Configuration.GetSection("BloggingPlatformDatabase"));
builder.Services.AddSingleton<ArticlesService>(); // DI with a singleton service lifetime

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
