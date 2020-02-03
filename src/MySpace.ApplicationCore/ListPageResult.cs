using MySpace.ApplicationCore.Entities;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.ApplicationCore
{
    public class ListPageResult<T> where T : BaseEntity, IAggregateRoot
    {
        public int total { get; set; }
        public IEnumerable<T> rows { get; set; }
    }
}
