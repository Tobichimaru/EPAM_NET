use [Northwind]
go

select Count(CustomerID), Country
from Customers
group by Country