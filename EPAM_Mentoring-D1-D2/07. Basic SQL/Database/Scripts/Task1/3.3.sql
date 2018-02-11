use [Northwind]
go

select CustomerID, Country
from Customers
where substring(Country,1,1) >= 'b' and substring(Country,1,1) <= 'g'
order by Country asc