using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using product_api.Data;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.Http;

namespace product_api
{
    public class Startup
    {
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod()
            //                          .WithMethods("PUT", "DELETE", "GET");
            //                      });
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Policy1",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://example.com",
            //                                "http://www.contoso.com");
            //        });

            //    options.AddPolicy("AnotherPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://www.contoso.com")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});
            services.AddControllers();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "product/dist";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "product_api", Version = "v1" });
            });

            services.AddDbContext<product_apiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("product_apiContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "product_api v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseCors();
            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                //endpoints.MapGet("/echo",
                //    context => context.Response.WriteAsync("echo"))
                //    .RequireCors(MyAllowSpecificOrigins);

                //endpoints.MapControllers()
                //         .RequireCors(MyAllowSpecificOrigins);
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/echo",
            //        context => context.Response.WriteAsync("echo"))
            //        .RequireCors(MyAllowSpecificOrigins);

            //    endpoints.MapControllers()
            //             .RequireCors(MyAllowSpecificOrigins);

            //    endpoints.MapGet("/echo2",
            //        context => context.Response.WriteAsync("echo2"));

            //    endpoints.MapRazorPages();
            //});

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "product";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
