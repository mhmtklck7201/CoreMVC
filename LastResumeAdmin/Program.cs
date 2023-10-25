using LastResume.Business.Abstract;
using LastResume.Business.Concrete;
using LastResume.Data.Abstract;
using LastResume.Data.Concrete.EFCore;
using LastResumeAdmin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LastResumeAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBlogRepository, EFBlogRepository>();
            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "MVCCoreAdmin";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Login";
            });
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false; //@ * gibi karakterler olmal�
                options.Lockout.MaxFailedAccessAttempts = 5; //5 giri�ten sonra kilitlenioyr. 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5); //5 dk sonra a��l�r
                options.Lockout.AllowedForNewUsers = true; //�sttekilerle alakal�
                                                           //options.User.AllowedUserNameCharacters = ""; //olmas�n� istedi�iniz kesin karaterrleri yaz
                options.User.RequireUniqueEmail = true; //unique emaail adresleri olsun her kullan�c�n�n 
                options.SignIn.RequireConfirmedEmail = true; //Kay�t olduktan email ile token g�nderecek 
                options.SignIn.RequireConfirmedPhoneNumber = false; //telefon do�rulamas�
            });
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
  
            builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
            var app = builder.Build();

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}