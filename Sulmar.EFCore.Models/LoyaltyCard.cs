using System;

namespace Sulmar.EFCore.Models
{
    public class LoyaltyCard : BaseEntity
    {
        public string SerialNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int OwnerId { get; set; }
        public Customer Owner { get; set; }
    }
}





