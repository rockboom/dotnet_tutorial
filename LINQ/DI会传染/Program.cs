using System;
using Microsoft.Extensions.DependencyInjection;
namespace DI_Basic_usage
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Conroller>();
            services.AddScoped<ILog,LogImpl>();
            //services.AddScoped<IConfig,ConfigImpl>();
            services.AddScoped<IConfig,DbConfigImpl>();
            services.AddScoped<IStorage, StorageImpl>();
            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<Conroller>();
                c.Test();
            }
        }
    }
    class Conroller
    {
        private readonly ILog log;
        private readonly IStorage storage;
        public Conroller(ILog log, IStorage storage)
        {
            this.log = log;
            this.storage = storage;
        }
        public void Test()
        {
            this.log.Log("开始上传");
            this.storage.Save("11111111111","1.txt");
            this.log.Log("上传完毕");
        }
    }
    interface ILog
    {
        void Log(string msg);
    }
    class LogImpl : ILog
    {
        public void Log(string msg)
        {
            Console.WriteLine($"记录日志:{msg}");
        }
    }
    interface IConfig
    {
        string GetValue(string name);
    }
    class ConfigImpl : IConfig
    {
        public string GetValue(string name)
        {
            return "Hello";
        }
    }
    class DbConfigImpl : IConfig
    {
        public string GetValue(string name)
        {
            Console.WriteLine("从数据库读取配置");
            return "Hello Db";
        }
    }
    interface IStorage
    {
        void Save(string content,string name);
    }
    class StorageImpl : IStorage
    {
        private readonly IConfig config;
        public StorageImpl(IConfig config)
        {
            this.config = config;
        }
        public void Save(string content, string name)
        {
            string server = config.GetValue("server");
            Console.WriteLine($"向服务器{server}的文件名为{name}上传{content}");
        }
    }
}
