using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{

    // dotnet add package Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public double Distance { get; set; }

        public Shop()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
