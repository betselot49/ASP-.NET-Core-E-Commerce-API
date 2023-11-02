using ECommerce.Application;
using ECommercePersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("ECommerceDbConnectionString"),
        new MariaDbServerVersion(new Version(5, 7, 0)),
        mysqlOptions => mysqlOptions
            .EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null));
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });
});


builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
       builder => builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
