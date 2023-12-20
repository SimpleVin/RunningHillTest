using RunningHillTest.Application.Mappers;
using RunningHillTest.Infrastructure;
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var assembly = typeof(Program).Assembly;
builder.Services.AddAutoMapper((typeof(Program).Assembly));
//Dependency Injection
builder.Services.AddPersistence(builder.Configuration);
var app = builder.Build();
app.UseCors("allowCors");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//builder.Services.AddValidatorsFromAssemblies(assembly);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
