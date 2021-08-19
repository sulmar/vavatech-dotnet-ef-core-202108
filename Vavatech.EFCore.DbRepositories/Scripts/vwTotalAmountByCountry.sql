CREATE VIEW dbo.vwTotalAmountByCountry AS
select 
	ShipAddress_Country as Country,
	sum(od.Quantity * od.UnitPrice) as TotalAmount

from Orders as o
	inner join Customers as c
		 on o.CustomerId = c.Id
	inner join OrderDetails as od
		on o.Id = od.OrderId
group by ShipAddress_Country