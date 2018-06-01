using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using EFCore.Infrastructure;
using EFCore.Interfaces;
using EFCore.Models.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;

namespace EFCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static IContainer AutofacContainer;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //在应用程序启动过程通过依赖注入注册——EF 数据库上下文服务
            services.AddDbContext<Data.SchoolContext>(options =>options.UseSqlServer(
                Configuration.GetConnectionString("TestConnection")));

            services.AddDbContext<Data.FlashPayContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")));


            services.AddTransient<IToDoItemRepository, ToDoItemRepository>();
            //services.AddTransient<ToDoItemRepository>();
            services.AddTransient<StatisticsService>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


             # region 性能监控
            //StackExchange.Profiling.MiniProfiler.Start();
            //StackExchange.Profiling.MiniProfilerEF.Initialize();
            //MiniProfilerEF.Initialize();
            //services.AddMvc(config =>{config.Filters.Add(new ProfilingActionFilter());});
             #endregion

            services.AddMvc();

            #region Autofac初始化
            ContainerBuilder builder = new ContainerBuilder();
            //将services中的服务填充到Autofac中.   
            builder.Populate(services);
            //创建容器.         
            AutofacContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider          
            return new AutofacServiceProvider(AutofacContainer);

            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            app.UseMiniProfiler();

            // The call to app.UseMiniProfiler must come before the call to app.UseMvc
            app.UseMvc();


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //程序停止调用函数         
            //appLifetime.ApplicationStopped.Register(() => { AutofacContainer.Dispose(); });
        }


  





    }
}
