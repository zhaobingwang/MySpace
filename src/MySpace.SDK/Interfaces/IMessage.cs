using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.Interfaces
{
    public interface IMessage
    {
        string AppId { get; }
        string AppSecret { get; }
        string GrantType { get; }
        string Url { get; }
        string GetAccessToken();

        //SendTemplateMessageResponse SendTemplateMessage(string accessToken, WxTemplateObject<WxTestTemplate> template);
    }
}
