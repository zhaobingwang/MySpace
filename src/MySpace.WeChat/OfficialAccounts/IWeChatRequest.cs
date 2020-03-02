using System.Collections.Generic;

namespace MySpace.WeChat.OfficialAccounts
{
    public interface IWeChatRequest<TResponse, TParamaters> where TResponse : WeChatResponse where TParamaters : WeChatObject
    {
        HttpMethod HttpMethod { get; }

        /// <summary>
        /// 请求参数
        /// </summary>
        TParamaters Parameters { get; set; }

        /// <summary>
        /// 获取接口名称
        /// </summary>
        /// <returns></returns>
        string GetApiName();
    }
}