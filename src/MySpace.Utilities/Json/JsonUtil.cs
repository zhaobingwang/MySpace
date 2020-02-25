using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using MySpace.Utilities.Extensions;

namespace MySpace.Utilities
{
    public static partial class JsonUtil
    {
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            if (json.IsNullOrWhiteSpace())
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <returns></returns>
        public static string ToJson(object target)
        {
            if (target == null)
                return string.Empty;
            var result = JsonSerializer.Serialize(target);
            return result;
        }
    }
}
