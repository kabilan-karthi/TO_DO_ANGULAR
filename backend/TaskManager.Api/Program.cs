using TaskManager.Api.Configuration;
using TaskManager.Api.Data.Interfaces;
using TaskManager.Api.Data.Mongo;
using TaskManager.Api.Services.Interfaces;
using TaskManager.Api.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Add services
// --------------------

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS (VERY IMPORTANT for Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// MongoDB settings
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

// Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// --------------------
// Middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ HTTPS redirection disabled for local dev
// app.UseHttpsRedirection();

// ✅ USE CORS BEFORE controllers
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
