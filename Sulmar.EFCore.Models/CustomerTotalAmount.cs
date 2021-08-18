using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class CustomerTotalAmount : Base
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
