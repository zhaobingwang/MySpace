﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySpace.Utilities
{
    /// <summary>
    /// 日期时间扩展
    /// </summary>
    public static partial class DateTimeExtensions
    {
        #region variables && constants
        /// <summary>
        /// 周未
        /// </summary>
        public static readonly DayOfWeek[] Weekend = { DayOfWeek.Saturday, DayOfWeek.Sunday };
        #endregion

        #region 特定时间格式
        /// <summary>
        /// 转为中文日期
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <returns></returns>
        public static string ToChineseDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 转为中文日期
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <returns></returns>
        public static string ToChineseDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return dateTime.Value.ToString("yyyy年MM月dd日");
            //return ToChineseDateString(dateTime.Value);
        }

        /// <summary>
        /// 转为中文日期时间
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <returns></returns>
        public static string ToChineseDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy年MM月dd日HH时mm分ss秒");
        }

        /// <summary>
        /// 转为中文日期时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToChineseDateTimeString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return dateTime.Value.ToString("yyyy年MM月dd日HH时mm分ss秒");
            //return ToChineseDateTimeString(dateTime.Value);
        }

        /// <summary>
        /// 转为yyyy-MM-dd格式字符串
        /// </summary>
        /// <param name="dateTime">时间日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转为yyyy-MM-dd格式字符串
        /// </summary>
        /// <param name="dateTime">时间日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return dateTime.Value.ToString("yyyy-MM-dd");
            //return ToDateString(dateTime.Value);    // 很容易忘记写.velue,造成死循环
        }
        #endregion

        #region 时间比较和判断
        /// <summary>
        /// 是否早于指定时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="targetDateTime">目标时间</param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dateTime, DateTime targetDateTime)
        {
            return dateTime.CompareTo(targetDateTime) < 0;
        }

        /// <summary>
        /// 是否晚于指定时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="targetDateTime"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dateTime, DateTime targetDateTime)
        {
            return dateTime.CompareTo(targetDateTime) > 0;
        }

        /// <summary>
        /// 是否是周末
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dateTime)
        {
            return Weekend.Any(d => d == dateTime.DayOfWeek);
        }

        /// <summary>
        /// 是否是今天
        /// </summary>
        /// <param name="dateTime"></param>
        public static bool IsToday(this DateTime dateTime, DateTime? today = null)
        {
            if (today == null)
                today = DateTime.Now;
            return dateTime.Date == today.Value.Date;
        }

        #endregion

        #region 特殊时间
        /// <summary>
        /// 转为给定时间的开始时刻
        /// 精确到秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToStartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }
        /// <summary>
        /// 转为给定时间的最后一刻
        /// 精确到秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToEndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }
        #endregion

        #region 其他
        /// <summary>
        /// 转为友好的时间信息
        /// 比如：1分钟前，3天前等
        /// XXX:一些较复杂判断先简单处理实现，比如昨天，上周，上个月等
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="now">如果为null,则取DateTime.Now</param>
        /// <returns></returns>
        public static string ToFriendlyDateString(this DateTime dateTime, DateTime? now = null)
        {
            if (now == null)
                now = DateTime.Now;
            var timeSince = now.Value.Subtract(dateTime);
            if (timeSince.TotalMinutes < 1)
                return "刚刚";
            if (timeSince.TotalMinutes < 2)
                return "1分钟前";
            if (timeSince.TotalMinutes < 60)
                return $"{timeSince.Minutes}分钟前";
            if (timeSince.TotalMinutes < 120)
                return "1小时前";
            if (timeSince.TotalHours < 24)
                return $"{timeSince.Hours}小时前";
            if (timeSince.TotalDays == 1)
                return "昨天";
            if (timeSince.TotalDays < 7)
                return $"{timeSince.Days}天前";
            if (timeSince.TotalDays < 14)
                return "上周";
            if (timeSince.TotalDays < 21)
                return "2周前";
            if (timeSince.TotalDays < 28)
                return "3周前";
            if (timeSince.TotalDays < 60)
                return "上个月前";
            if (timeSince.TotalDays < 365)
                return $"{Math.Floor(timeSince.TotalDays / 30)}个月前";
            if (timeSince.TotalDays < 730)
                return "去年";
            return $"{Math.Floor(timeSince.TotalDays / 365)}年前";
        }
        #endregion

    }
}
