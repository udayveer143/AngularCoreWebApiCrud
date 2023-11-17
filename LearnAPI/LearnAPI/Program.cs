using AutoMapper;
using LearnAPI.Container;
using LearnAPI.Helper;
using LearnAPI.Repos;
using LearnAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddDbContext<LearndataContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("apicon")));

var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => build.WithOrigins("https://www.domain1.com", "https://www.domain2.com").AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddCors(p => p.AddPolicy("corspolicy1", build => build.WithOrigins("https://www.domain3.com").AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddCors(p => p.AddDefaultPolicy(build => build.WithOrigins("https://www.domain3.com").AllowAnyMethod().AllowAnyHeader()));
string logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
var _logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("microsoft",Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(logpath)
    .CreateLogger();
builder.Services.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
