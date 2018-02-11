use [Northwind]
go

select (select e.FirstName + ' ' + e.LastName 
	from Employees e 
	where e.EmployeeID = o.EmployeeID) as Seller
, count(OrderID) as Amount
from Orders o
group by EmployeeID
