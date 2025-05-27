using AspNetCoreWebMVC;
using AspNetCoreWebMVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);  
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<EmployeeRepository>(); //Untuk menambah repo untuk pakai SP
//RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRotativa();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
