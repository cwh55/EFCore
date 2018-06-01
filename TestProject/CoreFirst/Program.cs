using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreFirst
{
    public class Program
    {
        public static object WebApplication { get; private set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
    }
}
