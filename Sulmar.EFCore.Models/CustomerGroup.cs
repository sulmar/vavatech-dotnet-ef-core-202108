using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class CustomerGroup : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Customer> Customers { get; set; }
    }
}
