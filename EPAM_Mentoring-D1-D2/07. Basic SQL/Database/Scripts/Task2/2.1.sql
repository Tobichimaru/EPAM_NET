use [Northwind]
go

select Count(OrderID) as 'Total',
	 year(ShippedDate) as 'Year'
from Orders
group by year(ShippedDate)