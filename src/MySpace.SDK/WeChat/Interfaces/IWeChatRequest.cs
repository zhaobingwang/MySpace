using MySpace.SDK.Models.WeChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat
{
    public interface IWeChatRequest<T> where T : WeChatResponse
    {
    }
}