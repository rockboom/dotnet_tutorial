using System;
using Microsoft.Extensions.DependencyInjection;
namespace Service_IOC
{
    public interface ITestService
    {
        public string Name { set; get; }
        void SayHello();
    }
    public class TestServiceTemplate1 : ITestService,IDisposable
    {
        public string Name { get ; set ; }

        public void Dispose()
        {
            Console.WriteLine("is been Disposable......");
        }

        public void SayHello()
        {
            Console.WriteLine($"Hi,I'm {Name}");
        }
    }

    public class TestServiceTemplate2 : ITestService
    {
        public string Name { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"你好，我是{Name}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddScoped<ITestService, TestServiceTemplate1>();
            //services.AddScoped(typeof(ITestService), typeof(TestServiceTemplate1));
            services.AddSingleton(typeof(ITestService), new TestServiceTemplate1());
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                ITestService ts1 =  sp.GetService<ITestService>();
                ts1.Name = "Bom";
                ts1.SayHello();
                Console.WriteLine(ts1.GetType());
                Console.WriteLine(ts1.GetHashCode());
            }
        }
        static void Main1(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddTransient<TestServiceTemplate1>();
            services.AddSingleton<TestServiceTemplate1>();
            //services.AddScoped<TestServiceTemplate1>();
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                //TestServiceTemplate1 testService = serviceProvider.GetService<TestServiceTemplate1>();
                //testService.Name = "Bruce";
                //testService.SayHello();

                //TestServiceTemplate1 t1 = serviceProvider.GetService<TestServiceTemplate1>();
                //bool isEqual = Object.ReferenceEquals(t1,testService);
                //Console.WriteLine(isEqual);

                TestServiceTemplate1 ttt1;
                using (IServiceScope scope1 = sp.CreateScope())
                {
                    // 在scope中获取Scope相关的对象 用scope1.ServiceProvider方法
                    TestServiceTemplate1 testService = scope1.ServiceProvider.GetService<TestServiceTemplate1>();
                    testService.Name = "Bruce";
                    testService.SayHello();

                    TestServiceTemplate1 t1 = scope1.ServiceProvider.GetService<TestServiceTemplate1>();
                    bool isEqual = Object.ReferenceEquals(t1, testService);
                    Console.WriteLine(isEqual);

                    ttt1 = t1;
                }

                using (IServiceScope scope2 = sp.CreateScope())
                {
                    // 在scope中获取Scope相关的对象 用scope1.ServiceProvider方法
                    TestServiceTemplate1 testService = scope2.ServiceProvider.GetService<TestServiceTemplate1>();
                    testService.Name = "Bruce";
                    testService.SayHello();

                    TestServiceTemplate1 t1 = scope2.ServiceProvider.GetService<TestServiceTemplate1>();
                    bool isEqual = Object.ReferenceEquals(t1, testService);
                    Console.WriteLine(isEqual);

                    Console.WriteLine(Object.ReferenceEquals(ttt1,t1));
                }
            }
        }
    }
}
