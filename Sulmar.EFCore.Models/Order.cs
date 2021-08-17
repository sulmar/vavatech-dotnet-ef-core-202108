using System;
using System.Collections.Generic;
using System.Linq;

namespace Sulmar.EFCore.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.LineAmount);

        public IEnumerable<Attachment> Attachments { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }
    }

    public enum OrderStatus
    {
        Ordered,
        Sent,
        Canceled,
        Shipped
    }
}





