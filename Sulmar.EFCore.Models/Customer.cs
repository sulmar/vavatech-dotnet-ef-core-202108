﻿using System;
using System.Collections.Generic;

namespace Sulmar.EFCore.Models
{
    public class Customer : BaseEntity
    {
        private bool isRemoved;
        private IEnumerable<CustomerGroup> customerGroups;

        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Pesel { get; set; }
        public CustomerType CustomerType { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual LoyaltyCard LoyaltyCard { get; set; }
        public virtual IEnumerable<CustomerGroup> CustomerGroups
        {
            get => customerGroups; set
            {
                customerGroups = value;
                OnPropertyChanged();
            }
        }


        public Coordinate Location { get; set; }

        public bool IsRemoved
        {
            get => isRemoved;
            set
            {
                isRemoved = value;
                OnPropertyChanged();
            }
        }
    }

    public enum CustomerType
    {
        Private,
        Company
    }
}





