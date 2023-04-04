using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DotNetCoreAngularApp.BusinessLogic.Services.Registration;
using DotNetCoreAngularApp.BusinessLogic.Services.Settings;
using DotNetCoreAngularApp.DataAccess;
using DotNetCoreAngularApp.Web.Models.Registration;
using DotNetCoreAngularApp.Web.Validators.Registration;
using DotNetCoreAngularApp.BusinessLogic.Factories.Settings;
using DotNetCoreAngularApp.BusinessLogic.Factories.User;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetCoreAngularApp API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextFactory<DotNetCoreAngularAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DotNetCoreAngularAppDb")));
builder.Services.AddTransient<ICountryFactory, CountryFactory>();
builder.Services.AddTransient<IProvinceFactory, ProvinceFactory>();
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IValidator<RegistrationModel>, RegistrationModelValidator>();

var app = builder.Build();

// Run migrations
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DotNetCoreAngularAppDbContext>>()
    .CreateDbContext();
context.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetCoreAngularApp API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
