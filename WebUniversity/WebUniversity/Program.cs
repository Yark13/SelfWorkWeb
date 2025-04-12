using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.UnitOfWork;
using WebUniversity.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddDbContext<StateDbContext>();
builder.Services.AddScoped<IUnitOfWork<StateDbContext>, UnitOfWork<StateDbContext>>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StateDbContext>();

// Check if the 'Courses' table exists before migrating
if (!dbContext.Database.GetPendingMigrations().Any())
{
    if (!dbContext.Database.GetAppliedMigrations().Any(m => m == dbContext.Database.GetAppliedMigrations().LastOrDefault()))
    {
        dbContext.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Logging}/{id?}");

app.Run();
