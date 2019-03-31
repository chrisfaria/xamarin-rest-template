namespace xTemplate.Mobile.Models
{
    public class SubItem
    {
        public long SubItemId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
