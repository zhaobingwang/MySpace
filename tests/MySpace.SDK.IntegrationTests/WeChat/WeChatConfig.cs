using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.IntegrationTests.WeChat
{
    public class WeChatConfig : BaseTest<WeChatConfig>
    {
        public static string AppId { get; set; }
        public static string AppSecret { get; set; }
        public static string ServerUrl { get; set; }
        public static string ToUser { get; set; }
        public static string TemplateId { get; set; }

        public WeChatConfig()
        {
            AppId = Configuration.GetSection("WeChat:Foundation:AppId").Value;
            AppSecret = Configuration.GetSection("WeChat:Foundation:AppSecret").Value;
            ServerUrl = Configuration.GetSection("WeChat:Foundation:ServerUrl").Value;
            ToUser = Configuration.GetSection("WeChat:TestData:UserId").Value;
            TemplateId = Configuration.GetSection("WeChat:TestData:TemplateId").Value;
        }
    }
}
