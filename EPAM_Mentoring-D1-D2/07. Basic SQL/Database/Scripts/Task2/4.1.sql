use [Northwind]
go

select CompanyName
from Suppliers 
where SupplierID  in (
	select SupplierID
	from Products
	where UnitsInStock = 0)
