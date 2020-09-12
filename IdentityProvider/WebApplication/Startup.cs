using System.Collections.Generic;
using Application.IdentityServer4;
using Application.Services;
using Application.Utilities;
using Core;
using Core.Entities;
using Elect.DI;
using FluentValidation.AspNetCore;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication()
            .AddGoogle("Google", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = Configuration.GetSection("Google")["ClientId"];
                options.ClientSecret = Configuration.GetSection("Google")["ClientSerect"];
            });

            services.AddCors(opts =>
            {
                opts.AddPolicy("Allows", builder =>
                {
                    builder.WithOrigins("*", "http://localhost:8100", "http://localhost", "http://localhost:5006")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddElectDI(_ =>
            {
                _.ListAssemblyName = new List<string>
                {
                      "Application" // will scan Application.dll and Application.*.dll
                };
            });

            services.AddScoped<Application.Utilities.ServiceResolver>(serviceProvider => key =>
            {
                if (key == "A")
                    return serviceProvider.GetService<Application.Utilities.ServiceA>();
                else if (key == "B")
                    return serviceProvider.GetService<Application.Utilities.ServiceB>();
                else
                    throw new KeyNotFoundException();
            });

            services.Configure<SmtpSettings>(Configuration.GetSection("Smtp"));
            services.Configure<EmailTemplate>(Configuration.GetSection("EmailTemplate"));

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Application.Validations.InputModelValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("Allows");

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
