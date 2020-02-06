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
        /// 获取所有的Key-Value形式的文本请求参数字典
        /// Key:参数名，Value:参数值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        IDictionary<string, string> GetParameters();
    }
}