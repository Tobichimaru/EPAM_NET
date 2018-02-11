use [Northwind]
go

select Count(case 
	when ShippedDate is null then 1 else null 
		end) 
from Orders
