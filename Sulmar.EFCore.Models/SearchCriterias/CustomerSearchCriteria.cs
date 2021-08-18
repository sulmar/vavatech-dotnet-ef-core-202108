using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models.SearchCriterias
{
    public class CustomerSearchCriteria : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirthFrom { get; set; }
        public DateTime? DateOfBirthTo { get; set; }
        public decimal? CreditFrom { get; set; }
        public decimal? CreditTo { get; set; }
        public bool? IsRemoved { get; set; }
    }
}
