using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class ApplicationUser : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
