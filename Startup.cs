using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using taxrun_API_new.Databases;

namespace taxrun_API_new
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment WebHostingEnvironment)
        {
            Configuration = configuration;

           // var configurationBuilder = new ConfigurationBuilder()
               // .SetBasePath(WebHostingEnvironment.ContentRootPath)
               // .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MandateUserContext>(option=>option.UseSqlServer(Configuration.GetConnectionString("MandateUserConnection")));
            services.AddMvc().AddXmlSerializerFormatters();

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MandateUserContext mandateUserContext)
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            mandateUserContext.Database.EnsureCreated(); //Only okay if you don't change table schema
            //mandateUserContext.Database.Migrate(); //Only okay if you are going to make changes to the table schema

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
