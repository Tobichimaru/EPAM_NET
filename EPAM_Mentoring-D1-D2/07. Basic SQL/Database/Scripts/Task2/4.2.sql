use [Northwind]
go

select e.EmployeeID, e.FirstName, e.LastName, o.OrdersCount from Employees e
join (
	select EmployeeID, count(*) as OrdersCount
	from Orders
	group by EmployeeID
	having count(*) > 150
) as o
on e.EmployeeID = o.EmployeeID
