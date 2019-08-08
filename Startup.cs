using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Identity;
using AspNetMvc2.Introduction.Models;
using AspNetMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMvc2.Introduction
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            

           // var connection = @"Server = (localdb)\mssqllocaldb;Database=SchoolDb;Trusted_Connection= true";
          
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(_configuration["dbConnection"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(_configuration["dbConnection"]));
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders(); // istekleri bu token üzerinden yönetiyoruz.


            //kurallar verebiliriz bu şekilde
            services.Configure<IdentityOptions>(options => {
                
                //Şifre için gereken Komutlar;


                //Şifrede sayı olması için
                options.Password.RequireDigit = true;
                //Şifrede büyük küçük uyumluğu olması için
                options.Password.RequireLowercase = true;
                //Şifre uzunluğu olması için
                options.Password.RequiredLength = 6;
                //Şifre AlfaNumerik olması için 
                options.Password.RequireNonAlphanumeric = true;
                //Şifrede büyük Harf mutlaka olamsı için
                options.Password.RequireUppercase = true;

                //Saldılara Karşı Korunmak için Gereken Komutlar;

                //Şifreyi max 3 kere girebilir
                options.Lockout.MaxFailedAccessAttempts = 3;
                //Sistemi ne kadar süre kullanamayacağını ayarladık
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //yeni Kullanıcılar içinde geçerli
                options.Lockout.AllowedForNewUsers = true;

                //
                options.User.RequireUniqueEmail = true;

                //Mail doğrulaması, Yeni login olduğunda kullanıcıdan istendiğinde maile gitmesi için
                options.SignIn.RequireConfirmedEmail = true;
                //telefon numarası doğrulama olması için 
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            //Cookie lere Ait Konfigurasyon yapılandırdık
            services.ConfigureApplicationCookie(options =>
            {
                //Kullanıcının Login olacağı path
                options.LoginPath = "/Security/Login";
                //Kişinin Logout olacağı path
                options.LogoutPath = "/Security/Logout";
                //Kişinin Erişim yetkisi Olmaması için istenilen aksiyona yönlendirme
                options.AccessDeniedPath = "/Security/AccesDenied";
                //Cookie nin default süresi bittinde sisteme yeniden girilmesi için gereken komut
                options.SlidingExpiration = true;

                options.Cookie = new CookieBuilder
                {   
                    HttpOnly = true,
                    //Default ismin dışında isimde verilebilir
                    Name=".AspNetCoreDemo.Security.Cookie",
                    //Cookie direk route Koymasi için
                    Path="/",
                    //Aını domainde Postman Vasıtayla erişim sağlamak için gereken komut
                    SameSite=SameSiteMode.Lax,
                    //Csurf ataklarını engellemek için bizim belirttiğimiz noktalardan istek göndermek için
                  //  SameSite=SameSiteMode.Strict,

                    //Yapılan istekle aynı olması için
                    SecurePolicy=CookieSecurePolicy.SameAsRequest

                };


            });


            services.AddScoped<ICalculator, Calculator8>();

            //Session Servislerini Tanımladık
            services.AddSession();

            //UYgulama Sunucusunun Hafızasında Tutulacak kısım
            services.AddDistributedMemoryCache();


            /* Sıklıkla Kullanılan Despencing Injection Yöntemleri
             

                Genellikle;
                
                services.AddScoped<>
                services.AddSingleton<> 

                kullanılır.
        
                        
             * Sıklıkla kullanılan sınıflar için AddSingleton<> kullanılır. 
           
            //services.AddSingleton<ICalculator, Calculator8>();

            * her kullanıcı için nesne oluşturlur ve işi bittikten sonra da bellekten 
             kaldırılır.
           
            //services.AddScoped<ICalculator, Calculator8>();

            * bu yöntem de vardır
             //services.AddTransient<ICalculator, Calculator8>(); 
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            
            //Hata Yakala Yöntemi 
           // env.EnvironmentName = EnvironmentName.Production;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Hata Sayfasına Yönlendirme 
                app.UseExceptionHandler("/error");
            }

            //Session Middleware Projemize ekledik.
            app.UseSession();

            //Kaynaklar üzerinde Authentication Yapmamız için kullanılır.
            app.UseAuthentication();


            app.UseMvc(configureRoutes);

            //app.UseMvc(routes =>
            //{
            //routes.MapRoute(

            //    name: "default",
            //    template:"{controller=home}/{action=index}/{id?}"
            //        );
            //});


            //app.Run (async (context) => {

            //    await context.Response.WriteAsync("Hello World!");

            //});



        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
            //routeBuilder.MapRoute("Default", "{controller=Filter}/{action=Index}/{id?}");
            // routeBuilder.MapRoute("MyRoute", "{Halil/controller=home}/{action=index2}/{id?}");

            //area ekledik.
                routeBuilder.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
          

        }
    }
}
