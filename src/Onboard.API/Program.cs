using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// add services to container

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>{o.ShortSchemaNames = true;});

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen(); 
app.Run();
