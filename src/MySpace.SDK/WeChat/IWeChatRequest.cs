using System.Collections.Generic;

namespace MySpace.SDK.WeChat
{
    public interface IWeChatRequest<T> where T : WeChatResponse
    {
        /// <summary>
        /// 获取接口名称
        /// </summary>
        /// <returns></returns>
        string GetApiName();

        /// <summary>
        /// 组装参数
        /// </summary>
        /// <returns></returns>
        string GetParameters();
    }
}