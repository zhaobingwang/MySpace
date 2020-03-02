using System.Threading.Tasks;

namespace MySpace.WeChat.OfficialAccounts
{
    public interface IWeChatClient
    {
        Task<TResponse> GetAccessToken<TResponse, TParameters>(IWeChatRequest<TResponse, TParameters> request, string grantType = null) where TResponse : WeChatResponse where TParameters : WeChatReqeustParamsObject;
        Task<TResponse> Execute<TResponse, TParameters>(IWeChatRequest<TResponse, TParameters> request, string accessToken) where TResponse : WeChatResponse where TParameters : WeChatReqeustParamsObject;
    }
}