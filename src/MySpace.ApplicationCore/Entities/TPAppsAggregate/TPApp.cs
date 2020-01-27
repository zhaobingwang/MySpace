using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.ApplicationCore.Entities.TPAppsAggregate
{
    /// <summary>
    /// 第三方应用
    /// </summary>
    public class TPApp : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public TPAppPassword Password { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
    }
}
