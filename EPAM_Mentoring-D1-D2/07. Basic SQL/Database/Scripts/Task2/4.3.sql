use [Northwind]
go

select * from Customers c
where not exists 
(
	select *
	from Orders o
	where o.CustomerID = c.CustomerID
)