using DiveDeep.Data;
using DiveDeep.Persistence;
using Microsoft.EntityFrameworkCore;
using DiveDeep.Service;
using Microsoft.AspNetCore.Identity;
namespace DiveDeep
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            { 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); 
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>();
               
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IPackageEquipmentSizeRequirementRepository, PackageEquipmentSizeRequirementRepository>();
            builder.Services.AddScoped<ICartItemEquipmentSizeRepository, CartItemEquipmentSizeRepository>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<PackageService>();

            var app = builder.Build();

   

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var scope = app.Services.CreateScope())
            {
                UserManager<ApplicationUser> userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();

                var admin = await userManager.FindByEmailAsync("admin@company.com");

                if (admin != null && !await userManager.IsInRoleAsync(admin, "Admin"))
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();

            app.Run();
        }
    }
}
