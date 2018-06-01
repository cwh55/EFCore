using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;

namespace EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            //添加测试数据
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);

                    //var context = services.GetRequiredService<FlashPayContext>();
                    //string str = Test.Initialize(context);

                    //Test2.Register();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            //var profiler = MiniProfiler.StartNew("My Pofiler Name");
            //using (profiler.Step("Main Work"))
            //{
            //}

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();


    }
}
