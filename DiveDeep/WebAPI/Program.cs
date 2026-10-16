using DiveDeep.Persistence;
using DiveDeep.Service;
using DiveDeep.Data;
using DiveDeepShared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<AdminService>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IPackageEquipmentSizeRequirementRepository, PackageEquipmentSizeRequirementRepository>();
            builder.Services.AddScoped<ICartItemEquipmentSizeRepository, CartItemEquipmentSizeRepository>();
            builder.Services.AddScoped<IDivingConditionsHttpService, DivingConditionsHttpService>();
            builder.Services.AddScoped<IBookingEquipmentSizeRepository, BookingEquipmentSizeRepository>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<PackageService>();

            builder.Services.AddHttpClient("OpenMeteoWeather", client => { client.BaseAddress = new Uri("https://api.open-meteo.com/"); });
            builder.Services.AddHttpClient("OpenMeteoGeocoding", client => { client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/"); });
            builder.Services.AddHttpClient("OpenMeteoMarine", client => { client.BaseAddress = new Uri("https://marine-api.open-meteo.com/"); });


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClient", policy =>
                    policy.WithOrigins("https://localhost:7240")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<DiveDeepContext>()
                .AddApiEndpoints();

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowClient");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapIdentityApi<ApplicationUser>();

            app.MapControllers();

            app.MapGet("/claims", (HttpContext context) =>
            {
                var claims = context.User.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                });
                return Results.Ok(claims);
            }).RequireAuthorization().RequireCors("AllowClient");

            app.Run();
        }
    }
}
