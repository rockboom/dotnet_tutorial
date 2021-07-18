using System;
using ConfigServices;
using LogServices;

namespace MailServices
{
    public class MailService:IMailService
    {
        private readonly ILogService log;
        //private readonly IConfigService config; // 从configReader中读取配置 不需要此配置
        private readonly IConfigReader config;
        
        //public MailService(ILogService log, IConfigService config)
        public MailService(ILogService log, IConfigReader config)
        {
            this.log = log;
            this.config = config;
        }

        public void Send(string title, string to, string body)
        {
            this.log.LogInfo("准备发送邮件");
            string smtpServer = this.config.GetValue("SmtpServer");
            string userName = this.config.GetValue("UserName");
            string password = this.config.GetValue("Password");
            Console.WriteLine($"邮件服务器地址: {smtpServer} {userName} {password}");
            Console.WriteLine($"真发邮件啦！！！{title},{to},{body}");
            this.log.LogInfo("邮件发送完成");
        }
    }
}
