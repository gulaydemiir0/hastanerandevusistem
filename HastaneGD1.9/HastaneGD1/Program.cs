using HastaneGD1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;

        }).AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddLocalization();
        builder.Services.AddRazorPages();
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
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var Roles = new[] { "administrator" };

            foreach (var role in Roles)
            {

                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string email = "web@sakarya.edu.tr";
            string password = "Sau123*";
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);


                await userManager.AddToRoleAsync(user, "administrator");

            }
        }
        app.Run();
    }
}