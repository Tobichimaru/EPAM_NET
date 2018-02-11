use [Northwind]
go

select OrderID, 
	'Shipped date' =   case   
		  when ShippedDate is null then 'Not shipped'
		  else cast(ShippedDate as varchar(12))
	end   
from Orders
