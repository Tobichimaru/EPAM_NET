use [Northwind]
go

select Sum(UnitPrice*Quantity - Discount) as 'Totals'
from [Order Details]
