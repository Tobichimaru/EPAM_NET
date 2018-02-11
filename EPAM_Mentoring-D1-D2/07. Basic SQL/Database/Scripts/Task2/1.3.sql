use [Northwind]
go

select Count(distinct CustomerID) as 'Count'
from Orders
