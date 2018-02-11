use [Northwind]
go

select c.CustomerID, c.City, e.City, e.EmployeeID
from Customers c, Employees e
where c.City in (select distinct City
      from Employees)
and c.City = e.City