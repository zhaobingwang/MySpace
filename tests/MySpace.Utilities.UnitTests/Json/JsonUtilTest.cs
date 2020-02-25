using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MySpace.Utilities.UnitTests
{
    [Trait("工具类", "Json")]
    public class JsonUtilTest
    {
        [Fact(DisplayName = "Json转对象-成功测试")]
        public void ToObject_ShouldSuccess_WithExpectedParameters()
        {
            var json = "{\"Location\":\"Hangzhou\",\"Temperature\":4,\"Date\":\"2019-11-19T11:55:46.0310797+00:00\"}";
            var result = JsonUtil.ToObject<WeatherForecast>(json);

            Assert.True(result.Location == "Hangzhou");
            Assert.True(result.Temperature == 4);
            Assert.IsType<DateTimeOffset>(result.Date);
        }
        class WeatherForecast
        {
            public string Location { get; set; }
            public int Temperature { get; set; }
            public DateTimeOffset Date { get; set; }
        }

    }
}
