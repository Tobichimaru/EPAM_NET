use [Northwind]
go

select c.ContactName,
	sum(o.OrderID) as 'Total'
from Customers c
join Orders o
on o.CustomerID = c.CustomerID
group by c.ContactName