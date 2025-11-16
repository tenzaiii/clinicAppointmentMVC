using Microsoft.AspNetCore.Identity;
using clinicAppointmentMVC.Data;
using clinicAppointmentMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace clinicAppointmentMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Get connection string from configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add Entity Framework with Identity
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Add Identity services
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Configure Identity options
                options.SignIn.RequireConfirmedAccount = false; // Set to true if you want email confirmation
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                // Add other password requirements as needed
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Add authentication
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication(); // Important: Add this before UseAuthorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}