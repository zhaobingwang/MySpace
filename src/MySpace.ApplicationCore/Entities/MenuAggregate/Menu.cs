using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.ApplicationCore.Entities.MenuAggregate
{
    public class Menu : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public int ParentId { get; set; }
        public short IsShow { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
    }
}