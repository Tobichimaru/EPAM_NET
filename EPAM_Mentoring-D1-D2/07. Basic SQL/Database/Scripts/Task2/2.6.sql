use [Northwind]
go

select EmployeeID, ReportsTo
from Employees
where ReportsTo is not null