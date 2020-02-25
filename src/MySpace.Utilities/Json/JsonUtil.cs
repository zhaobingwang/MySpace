using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MySpace.Utilities
{
    public static partial class JsonUtil
    {
        public static T ToObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
