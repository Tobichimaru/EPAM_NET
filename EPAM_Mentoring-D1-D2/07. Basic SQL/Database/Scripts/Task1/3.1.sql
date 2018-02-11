use [Northwind]
go

select distinct OrderID,
	Quantity
from [Order Details]
where Quantity between 3 and 10