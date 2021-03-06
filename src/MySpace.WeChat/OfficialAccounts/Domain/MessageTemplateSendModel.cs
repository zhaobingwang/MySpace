﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Domain
{
    /// <summary>
    /// 模板消息数据结构
    /// </summary>
    /// <typeparam name="TTemplate">模板 格式参照https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Template_Message_Interface.html#5</typeparam>
    public class MessageTemplateSendModel<TTemplate> : WeChatReqeustParamsObject
        where TTemplate : class
    {
        [JsonPropertyName("touser")]
        [Required]
        public string ToUser { get; set; }

        [JsonPropertyName("template_id")]
        [Required]
        public string TemplateId { get; set; }

        [JsonPropertyName("data")]
        public TTemplate Template { get; set; }
    }
}
