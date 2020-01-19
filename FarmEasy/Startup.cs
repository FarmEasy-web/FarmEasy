using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using FarmEasy.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FarmEasy.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
//using FarmEasy.Areas.Identity.Pages.Account;


namespace FarmEasy
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<UserMaster>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<RoleMaster>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender,EmailSender>();
            services.AddAuthentication()
                .AddGoogle(options=>
                {
                    IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:Google");
                    options.ClientId = googleAuthSection["ClientId"];
                    options.ClientSecret = googleAuthSection["ClientSecret"];
                })                
                .AddFacebook(options=>{
                    IConfigurationSection fbAuthSection = Configuration.GetSection("Authentication:Facebook");
                    options.AppId = fbAuthSection["AppId"];
                    options.AppSecret = fbAuthSection["AppSecret"];
                });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateRoles(serviceProvider).Wait();
            CreateAdmin(serviceProvider).Wait();
        }
        private async Task CreateAdmin(IServiceProvider serviceProvider)
        {
            var _userManager = serviceProvider.GetRequiredService<UserManager<UserMaster>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<RoleMaster>>();
            var user = new UserMaster { UserName = "administrator@gmail.com", Email = "administrator@gmail.com", FirstName = "Admin", LastName = "Admin",EmailConfirmed=true,IsDeleted=false, LockoutEnabled=true };
            var userResult = await _userManager.CreateAsync(user, "Test@123");
            var adminrole = await _roleManager.FindByNameAsync("Admin");
            var userroleresult = await _userManager.AddToRoleAsync(user, adminrole.Name);
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<RoleMaster>>();
           

            string[] roleNames = {"Admin","Farmer","Laboratry"};
           
            foreach(var roleName in roleNames)
            {             
                var roleResult = await _roleManager.CreateAsync(new RoleMaster { Name =roleName });
                if(roleResult.Succeeded)
                {
                    //_logger.LogInformation("Role Is Created");
                }
                else
                {
                    foreach(var error in roleResult.Errors)
                    {
                        //logger.LogInformation(error.Description);
                    }
                }
            }

        }
    }
}
