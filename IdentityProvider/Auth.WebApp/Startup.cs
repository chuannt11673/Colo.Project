using Auth.WebApp.IdentityServer4;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Auth.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddIdentityServer()
               .AddInMemoryIdentityResources(Config.IdentityResources)
               .AddInMemoryClients(Config.Clients);

            builder.AddDeveloperSigningCredential();

            services.AddAuthentication().AddGoogle("Google", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                options.ClientId = "1071965663222-9rf9aumd8ga6c80lcmf62ovng2h52957.apps.googleusercontent.com";
                options.ClientSecret = "5wCD3JnPrg-y5I_pQS2dys3y";
            });

            services.AddCors(opts =>
            {
                opts.AddPolicy("MyPolicy", builder =>
                {
                    builder.WithOrigins("*", "http://localhost:8100", "http://localhost")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthorization();
            services.AddControllersWithViews().AddXmlSerializerFormatters().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
