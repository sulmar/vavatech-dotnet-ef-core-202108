using NetTopologySuite.Geometries;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.IRepositories
{
    public interface IShopRepository
    {
        IEnumerable<Shop> Get();

        IEnumerable<Shop> Get(Point point, int distance);
    }
}
