use [Northwind]
go

select OrderID as 'Order Number', 
	ISNULL(cast(ShippedDate as varchar(12)), 'Not shipped') as 'Shipped Date'
from Orders
where cast(ShippedDate as date) > '1998-05-06' or ShippedDate is null
