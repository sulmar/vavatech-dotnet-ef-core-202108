using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sulmar.EFCore.Models
{
    public class Order : BaseEntity
    {
        private readonly ILazyLoader lazyLoader;

        public DateTime OrderDate { get; set; }

        private Customer customer;
        public Customer Customer { get => lazyLoader.Load(this, ref customer); set => customer = value; }

        private ICollection<OrderDetail> details;
        public ICollection<OrderDetail> Details { get => lazyLoader.Load(this, ref details); set => details = value; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.LineAmount);

        public virtual IEnumerable<Attachment> Attachments { get; set; }

        public Order(ILazyLoader lazyLoader)
        {
            Details = new List<OrderDetail>();
            this.lazyLoader = lazyLoader;
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





