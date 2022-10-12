using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentAModel.DataAccess;
using RentAModel.DataAccess.UnitofWork;
using RentAMovie.DTO.Configuration;
using RentAMovie.Models;
using RentAMovie.Services.Implementations;
using RentAMovie.Services.Interfaces;
using RentAMovie.WebAPI;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    op => op.SerializerSettings.ReferenceLoopHandling =
          Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddDbContext<RentAMovieDbCotext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentAMovie", Version = "v1" });
    });
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddTransient<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(Configuration);

builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: "D:\\Practices\\Logs\\RentAMovie\\log-.txt",
    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {UserId} {Event} - {Message}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information

    ).CreateLogger();
var app = builder.Build();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentAMovie v1");
    });
}
RentAMovieDbCotext context;
using (var scope = app.Services.CreateScope())
{
    context = scope.ServiceProvider.GetRequiredService<RentAMovieDbCotext>();
    await context.Database.MigrateAsync();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Member>>();
    await RentAMovieInitializer.SeedData(context, userManager);
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();
try
{
    Log.Information("Application is Starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");
    throw;
}
finally
{
    Log.CloseAndFlush();
}

