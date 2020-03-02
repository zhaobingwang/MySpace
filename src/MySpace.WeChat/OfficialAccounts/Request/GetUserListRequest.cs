using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.WeChat.OfficialAccounts.Request
{
    /// <summary>
    /// 获取用户列表接口
    /// https://api.weixin.qq.com/cgi-bin/user/get
    /// </summary>
    public class GetUserListRequest : IWeChatRequest<GetUserListResponse, GetUserListModel>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;

        public GetUserListModel Parameters { get; set; }

        public string GetApiName()
        {
            return "user/get";
        }
    }
}
