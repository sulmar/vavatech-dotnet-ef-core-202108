using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class TotalAmountCountryConfiguration : IEntityTypeConfiguration<TotalAmountCountry>
    {
        public void Configure(EntityTypeBuilder<TotalAmountCountry> builder)
        {
            builder.HasNoKey();

            // builder.ToView("vwTotalAmountByCountry", "dbo");

            //string sql = @"select 
	           //                 ShipAddress_Country as Country,
	           //                 sum(od.Quantity * od.UnitPrice) as TotalAmount

            //                from Orders as o
	           //                 inner join Customers as c
		          //                   on o.CustomerId = c.Id
	           //                 inner join OrderDetails as od
		          //                  on o.Id = od.OrderId
            //                group by ShipAddress_Country";

            //builder.ToSqlQuery(sql);

            builder.ToFunction("TotalAmountByCountry");
        }
    }
}
