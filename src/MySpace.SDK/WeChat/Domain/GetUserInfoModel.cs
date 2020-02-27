using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MySpace.SDK.WeChat.Domain
{
    public class GetUserInfoModel
    {
        public string openid { get; set; }
        public string lang { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            return GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(this, null)?.ToString());
        }
    }
}
