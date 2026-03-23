using Microsoft.EntityFrameworkCore;
using APIs.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Connect Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// CORS: allow Blazor dev client(s). Replace the origins below with your Blazor app URL(s).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDevClient", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7219", // example Blazor client https URL - replace with your client origin
                "http://localhost:5002"   // example additional origin if needed
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
            //.AllowCredentials(); // remove if not using credentials
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS globally using the named policy
app.UseCors("AllowBlazorDevClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
