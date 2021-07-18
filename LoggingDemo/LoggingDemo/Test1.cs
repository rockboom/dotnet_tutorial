using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace LoggingDemo
{
    public class Test1
    {
        private readonly ILogger<Test1> logger;
        public Test1(ILogger<Test1> logger)
        {
            this.logger = logger;
        }
        public void Test()
        {
            this.logger.LogDebug("开始执行数据库同步数据");
            this.logger.LogDebug("连接数据库成功");
            this.logger.LogWarning("查找数据失败，重试第一次");
            this.logger.LogWarning("查找数据失败，重试第二次");
            this.logger.LogError("查找数据失败");
            try
            {
                File.ReadAllLines("D:/a.txt");
                this.logger.LogDebug("读取文件成功");
            }
            catch (Exception ex)
            {
                this.logger.LogDebug(ex,"读取文件失败");
            }

        }
    }
}
