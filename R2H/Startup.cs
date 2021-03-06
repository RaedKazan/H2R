﻿using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.ApplicationDbContext;
using ApplicationDomianEntity.IdentityModels;
using ApplicationDomianEntity.Models;
using ApplicationService;
using ApplicationService.CustomerServices;
using ApplicationService.Orders;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using R2H.Models;
using System;

namespace R2H
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();

        }
        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
              services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<R2HDbContext>(options =>
                           options.UseSqlServer(Configuration.GetConnectionString("Panda"))).AddUnitOfWork<R2HDbContext>();
            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterType<R2HDbContext>().As<DbContext>().WithParameter("ConnectionStrings", "ConnectionStringValue").InstancePerLifetimeScope();
            builder.RegisterType<ElectricCigaretService>().As<IElectricCigaretService>();
            builder.RegisterType<LookUpService>().As<ILookUpService>();
            builder.RegisterType<ItemMangmentService>().As<IItemMangmentService>();
            builder.RegisterType<JuiceService>().As<IJuiceService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


            //added by hussam for user idientity
            services.AddIdentity<ApplicationUser, ApplicationRole>(option => option.Stores.MaxLengthForKeys = 128).
                 AddEntityFrameworkStores<R2HDbContext>().AddDefaultUI().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            builder.Populate(services);
            var container = builder.Build();



            //Create the IServiceProvider based on the container.
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,R2HDbContext 
            context,RoleManager<ApplicationRole>roleManager,UserManager<ApplicationUser>userManager )
        { // Use Threenine.Map to wire up the Automapper mappings

            //Added by Hamza
            loggerFactory.AddLog4Net(); // << Add this line

           

            //Added by hussam

            var UserName = Configuration.GetSection("InitilaizeAdmin")["UserName"];
            var Password = Configuration.GetSection("InitilaizeAdmin")["Password"];

            app.UseSession();

            // Ensure the Database is created
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<R2HDbContext>().Database.EnsureCreated();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
         

            InitializeUser.Initialize(context, userManager, roleManager,UserName,Password).Wait();
        }


      
    }
}
