using MySpace.SDK.Interfaces;
using MySpace.SDK.Models.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MySpace.SDK.Services.Message
{
    public abstract class BaseMessage : IMessage
    {
        public string AppId { get; }
        public string AppSecret { get; }
        public string GrantType { get; }

        public abstract string Url { get; set; }

        protected BaseMessage(string appId, string appSecret, string grantType = "client_credential")
        {
            AppId = appId;
            AppSecret = appSecret;
            GrantType = grantType;
        }

        public virtual object GetAccessToken()
        {
            if (string.IsNullOrEmpty(Url))
                throw new ArgumentNullException(nameof(Url));
            return HttpService.HttpGet(Url);
        }
    }
}
