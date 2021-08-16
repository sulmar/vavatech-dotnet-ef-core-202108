using System;
using System.Collections.Generic;

namespace Sulmar.EFCore.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Pesel { get; set; }
        public CustomerType CustomerType { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }
        public bool IsRemoved { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
    }

    public enum CustomerType
    {
        Private,
        Company
    }
}





