using MySpace.SDK.Models.WeChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat
{
    public class DefaultWeChatClient : IWeChatClient
    {
        private readonly string serverUrl;
        public T Execute<T>(IWeChatRequest<T> request, string accessToken) where T : WeChatResponse
        {
            throw new NotImplementedException();
        }
    }
}
