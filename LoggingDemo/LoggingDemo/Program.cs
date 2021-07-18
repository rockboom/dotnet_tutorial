﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SystemServices;

namespace LoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder=>
            {
                logBuilder.AddConsole();
                //logBuilder.AddEventLog();
                logBuilder.AddNLog();
                logBuilder.SetMinimumLevel(LogLevel.Trace);
            });
            services.AddScoped<Test1>();
            services.AddScoped<Test2>();
            using (var sp = services.BuildServiceProvider())
            {
                Test1 test = sp.GetService<Test1>();
                test.Test();

                Test2 test2 = sp.GetService<Test2>();
                test2.Test();
            }
        }
    }
}
