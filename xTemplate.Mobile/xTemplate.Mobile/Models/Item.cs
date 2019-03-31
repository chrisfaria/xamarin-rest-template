using System.Collections.Generic;

namespace xTemplate.Mobile.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public List<SubItem> SubItems { get; set; }
    }
}
