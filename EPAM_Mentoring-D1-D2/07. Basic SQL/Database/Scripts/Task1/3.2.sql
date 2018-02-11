use [Northwind]
go

select CustomerID, Country
from Customers
where substring(Country,1,1) between 'b' and 'g'
order by Country asc