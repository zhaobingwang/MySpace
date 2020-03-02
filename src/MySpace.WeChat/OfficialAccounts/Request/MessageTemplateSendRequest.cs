using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Response;

namespace MySpace.WeChat.OfficialAccounts.Request
{
    public class MessageTemplateSendRequest<TTemplate> : IWeChatRequest<MessageTemplateSendResponse, MessageTemplateSendModel<TTemplate>>
        where TTemplate : class
    {
        public HttpMethod HttpMethod => HttpMethod.Post;

        public MessageTemplateSendModel<TTemplate> Parameters { get; set; }

        public string GetApiName()
        {
            return "message/template/send";
        }
    }
}
