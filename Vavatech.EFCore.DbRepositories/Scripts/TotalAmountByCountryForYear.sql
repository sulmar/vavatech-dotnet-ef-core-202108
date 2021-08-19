CREATE FUNCTION dbo.TotalAmountByCountryForYear(@year int)
RETURNS TABLE
AS
RETURN
(
	select 
		ShipAddress_Country as Country,
		sum(od.Quantity * od.UnitPrice) as TotalAmount

	from Orders as o
		inner join Customers as c
			 on o.CustomerId = c.Id
		inner join OrderDetails as od
			on o.Id = od.OrderId
	where
		year(c.CreatedOn) = @year
	group by 
		ShipAddress_Country
)