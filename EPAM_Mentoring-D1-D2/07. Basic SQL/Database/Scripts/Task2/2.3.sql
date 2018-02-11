use [Northwind]
go

select Count(OrderID) as 'Total',
	CustomerID,
	EmployeeID
from dbo.Orders
where Year(ShippedDate) = 1998
group by CustomerID, EmployeeID
order by EmployeeID
