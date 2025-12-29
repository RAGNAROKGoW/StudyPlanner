using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC services
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
// 2. Add DbContext BEFORE builder.Build()
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("CONNECTION STRING USED:");
Console.WriteLine(cs);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// 3. Build the app
var app = builder.Build();

// 4. Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// 5. Map routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
