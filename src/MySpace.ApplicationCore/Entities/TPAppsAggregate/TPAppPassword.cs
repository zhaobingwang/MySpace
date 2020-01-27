using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.ApplicationCore.Entities.TPAppsAggregate
{
    public class TPAppPassword : BaseEntity, IAggregateRoot
    {
        public string CurrentPasswordHash { get; set; }
        public string LastPasswordHash { get; set; }
        public DateTimeOffset? ExpiredTime { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
    }
}
