using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFirst
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
           
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string path = contentRootPath+"\\AppSetting.json";
            var builder = new ConfigurationBuilder().AddJsonFile(path);
            Configuration = builder.Build();
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello World!");
                var msg = Configuration["message"];
                await context.Response.WriteAsync(msg);
            });
        }

       

    }
}
