using System;
using System.Collections.Generic;

namespace xTemplate.API.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<SubItem> SubItems { get; set; }
    }
}
