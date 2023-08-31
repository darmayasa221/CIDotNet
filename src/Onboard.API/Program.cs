using Autofac.Extensions.DependencyInjection;
// using Onboard.Core;
// using Onboard.API;
using Microsoft.OpenApi.Models;
using Serilog;
// using Ardalis.ListStartupServices;
using Autofac;
// using Onboard.Core;
using Onboard.Infrastructure;
using Onboard.Infrastructure.Data;
using Onboard.Web;
// using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

string connectionString = builder.Configuration.GetConnectionString("MysqlConnection");  //Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext(connectionString);

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
  c.EnableAnnotations();
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  // containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});
var app = builder.Build();
app.UseRouting();
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
app.UseEndpoints(endpoints =>
{
  endpoints.MapDefaultControllerRoute();
});

// Seed Database
/*
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    //context.Database.Migrate();
    context.Database.EnsureCreated();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}
*/


app.Run();
