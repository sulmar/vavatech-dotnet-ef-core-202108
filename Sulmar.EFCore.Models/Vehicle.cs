using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class Vehicle : BaseEntity
    {
        public string Name { get; set; }
        public float Capacity { get; set; }

        public string Model { get; set; }
    }
}
