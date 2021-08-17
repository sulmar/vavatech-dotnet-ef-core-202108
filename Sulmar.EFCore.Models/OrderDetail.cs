using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Sulmar.EFCore.Models
{
    public class OrderDetail : BaseEntity
    {
        private readonly ILazyLoader lazyLoader;
        
        private Item item;
        public Item Item { get => lazyLoader.Load(this, ref item); set => item = value; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineAmount => Quantity * UnitPrice;

        public virtual Order Order { get; set; }

        public OrderDetail(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public OrderDetail(Item item, int quantity = 1)
        {
            Item = item;
            UnitPrice = item.UnitPrice;
            Quantity = quantity;
        }
    }
}





