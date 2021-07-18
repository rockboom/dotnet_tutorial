using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace SystemServices
{
    public class Test2
    {
        private readonly ILogger<Test2> logger;
        public Test2(ILogger<Test2> logger)
        {
            this.logger = logger;
        }
        public void Test()
        {
            this.logger.LogDebug("开始执行FTP同步数据");
            this.logger.LogDebug("连接FTP成功");
            this.logger.LogWarning("查找数据失败，重试第一次");
            this.logger.LogWarning("查找数据失败，重试第二次");
            this.logger.LogError("查找数据失败");
        }
    }
}