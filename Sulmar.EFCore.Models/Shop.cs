using NetTopologySuite.Geometries;
using System;

namespace Sulmar.EFCore.Models
{

    // dotnet add package NetTopologySuite
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
