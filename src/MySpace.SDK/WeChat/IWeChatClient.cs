using System.Threading.Tasks;

namespace MySpace.SDK.WeChat
{
    public interface IWeChatClient
    {
        Task<T> GetAccessToken<T>(IWeChatRequest<T> request, string grantType = null) where T : WeChatResponse;
        Task<T> Execute<T>(IWeChatRequest<T> request, string accessToken) where T : WeChatResponse;
    }
}