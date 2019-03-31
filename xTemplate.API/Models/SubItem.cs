using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace xTemplate.API.Models
{
    public class SubItem
    {
        public long SubItemId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        [ForeignKey("Item")]
        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
