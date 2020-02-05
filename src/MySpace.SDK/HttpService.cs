using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.SDK
{
    public class HttpService
    {
        /// <summary>
        /// 发起同步Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">表示 RFC 2616 中定义的请求标头</param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// 发起异步Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">表示 RFC 2616 中定义的请求标头</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// 发起同步Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">Post数据</param>
        /// <param name="contentType">表示使用 Content-Type 标头的在 RFC 2616 中定义的媒体类型</param>
        /// <param name="timeOut">请求超时前等待的时间跨度（秒）</param>
        /// <param name="headers">表示 RFC 2616 中定义的请求标头</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData = null, string contentType = null, double timeOut = 60, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// 发起异步Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">Post数据</param>
        /// <param name="contentType">表示使用 Content-Type 标头的在 RFC 2616 中定义的媒体类型</param>
        /// <param name="timeOut">请求超时前等待的时间跨度（秒）</param>
        /// <param name="headers">表示 RFC 2616 中定义的请求标头</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string postData = null, string contentType = null, double timeOut = 60, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = await client.PostAsync(url, httpContent);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
