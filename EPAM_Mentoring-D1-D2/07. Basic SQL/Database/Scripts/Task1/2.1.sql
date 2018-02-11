use [Northwind]
go

select ContactName, Country
from Customers
where Country in ('USA', 'Canada')
order by ContactName asc, Country asc