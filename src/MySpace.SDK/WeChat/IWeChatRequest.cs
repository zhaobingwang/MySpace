using System.Collections.Generic;

namespace MySpace.SDK.WeChat
{
    public interface IWeChatRequest<T> where T : WeChatResponse
    {
        HttpMethod HttpMethod { get; }


        // XXX: 待优化 GET和 POST参数
        IDictionary<string, string> GetRequestParameters { get; set; }

        string PostRequestJsonData { get; set; }

        /// <summary>
        /// 获取接口名称
        /// </summary>
        /// <returns></returns>
        string GetApiName();
    }
}