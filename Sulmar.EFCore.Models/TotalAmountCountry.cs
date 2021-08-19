using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class TotalAmountCountry : Base
    {
        public decimal TotalAmount { get; set; }

        public string Country { get; set; }
    }
}
