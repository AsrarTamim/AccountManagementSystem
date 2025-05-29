using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevSkill.Inventory.Web.Models;
using AccountManagementSystem.Web.Data;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateBootstrapLogger();

try
{
    Log.Information("App is starting2");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule());
    });
    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    #region Serilog Configuration
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)
    );
    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();


    app.MapRazorPages()
       .WithStaticAssets();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"EXCEPTION: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
    Log.Fatal(ex, "Application Crashed");
}
finally
{
    Log.CloseAndFlush();
}
