namespace Sulmar.EFCore.Models
{
    public class OrderDetail : BaseEntity
    {
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineAmount => Quantity * UnitPrice;

        public virtual Order Order { get; set; }

        public OrderDetail()
        {

        }

        public OrderDetail(Item item, int quantity = 1)
            : this()
        {
            Item = item;
            UnitPrice = item.UnitPrice;
            Quantity = quantity;
        }
    }
}





