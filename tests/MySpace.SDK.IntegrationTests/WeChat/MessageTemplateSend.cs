﻿using MySpace.SDK.WeChat;
using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.SDK.IntegrationTests.WeChat
{
    [Trait("微信", "公众号")]
    public class MessageTemplateSend : BaseTest<MessageTemplateSend>
    {
        private string appId;
        private string appSecret;
        private string serverUrl;
        private string toUser;
        private string templateId;
        public MessageTemplateSend()
        {
            appId = Configuration.GetSection("WeChat:Foundation:AppId").Value;
            appSecret = Configuration.GetSection("WeChat:Foundation:AppSecret").Value;
            serverUrl = Configuration.GetSection("WeChat:Foundation:ServerUrl").Value;
            toUser = Configuration.GetSection("WeChat:TestData:UserId").Value;
            templateId = Configuration.GetSection("WeChat:TestData:TemplateId").Value;
        }
        [Fact(DisplayName = "模板消息发生成功")]
        public async Task MessageTemplateSendShouldSuccess()
        {
            IWeChatClient client = new DefaultWeChatClient(serverUrl, appId, appSecret);

            var requestToken = new GetAccessTokenReqeust();
            var resultToken = await client.GetAccessToken(requestToken);
            var token = resultToken.AccessToken;

            var request = new MessageTemplateSendRequest();
            var model = new MessageTemplateSendModel<Template>();
            model.ToUser = toUser;
            model.TemplateId = templateId;
            model.Template = new Template
            {
                Head = new TemplateContent
                {
                    Value = "恭喜你购买成功！",
                    Color = "#173177"
                },
                ProductName = new TemplateContent
                {
                    Value = "巧克力",
                    Color = "#173177"
                },
                TotalPrice = new TemplateContent
                {
                    Value = "39.8元",
                    Color = "#173177"
                },
                PayTime = new TemplateContent
                {
                    Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Color = "#173177"
                },
                Remark = new TemplateContent
                {
                    Value = "欢迎再次购买！",
                    Color = "#173177"
                }
            };

            request.PostJsonData = JsonSerializer.Serialize(model);
            var result = await client.Execute(request, token);
            Assert.True(result.ErrorCode == 0);
        }
        class Template
        {
            [JsonPropertyName("Head")]
            public TemplateContent Head { get; set; }

            [JsonPropertyName("ProductName")]
            public TemplateContent ProductName { get; set; }

            [JsonPropertyName("TotalPrice")]
            public TemplateContent TotalPrice { get; set; }

            [JsonPropertyName("PayTime")]
            public TemplateContent PayTime { get; set; }

            [JsonPropertyName("Remark")]
            public TemplateContent Remark { get; set; }
        }
        class TemplateContent
        {
            [JsonPropertyName("value")]
            public string Value { get; set; }

            [JsonPropertyName("color")]
            public string Color { get; set; }
        }
    }
}