using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.OData.Builder;

namespace CastProblem20200624
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CastProblemDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("CastProblemDbContext"), opts =>
                {
                    opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                });
            });


            services.AddControllers(mvcOptions =>
            {
                //mvcOptions.EnableEndpointRouting = false; // (HD) Commented out for 7.4.0-Beta.
                mvcOptions.AllowEmptyInputInBodyModelBinding = true;
                mvcOptions.MaxIAsyncEnumerableBufferLimit = 100000; // (HD) 20200226 https://stackoverflow.com/questions/58986882/asyncenumerablereader-reached-the-configured-maximum-size-of-the-buffer-when-e
            }); //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1); // (HD) Commented out for 7.4.0-Beta. // (HD) 20200213 According to https://devblogs.microsoft.com/odata/experimenting-with-odata-in-asp-net-core-3-1/.

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute("odata", "odata", GetEdmModel()); // (HD) For 7.4.0-Beta.
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new HDODataConventionModelBuilder();
            return builder.GetEdmModel();
        }
    }
}
