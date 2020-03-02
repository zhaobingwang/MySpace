using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts
{
    public static class Extensions
    {
        public static Dictionary<string, string> ToDictionary(this WeChatReqeustParamsObject obj)
        {
            return obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.GetCustomAttribute<JsonPropertyNameAttribute>().Name ?? prop.Name, prop => prop.GetValue(obj, null)?.ToString());
        }
    }
}
