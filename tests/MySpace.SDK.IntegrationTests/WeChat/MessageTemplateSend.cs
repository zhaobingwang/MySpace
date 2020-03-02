using MySpace.SDK.WeChat;
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
    public class MessageTemplateSend : WeChatConfig
    {
        [Fact(DisplayName = "模板消息发生成功")]
        public async Task MessageTemplateSendShouldSuccess()
        {
            IWeChatClient client = new DefaultWeChatClient(ServerUrl, AppId, AppSecret);

            var requestToken = new GetAccessTokenReqeust();
            var resultToken = await client.GetAccessToken(requestToken);
            var token = resultToken.AccessToken;

            var request = new MessageTemplateSendRequest<Template>();
            var model = new MessageTemplateSendModel<Template>();
            model.ToUser = OpenID;
            model.TemplateId = TemplateId;
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

            request.Parameters = model;
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
