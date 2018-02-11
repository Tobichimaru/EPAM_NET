use [Northwind]
go

select FirstName,
	LastName,
	r.RegionDescription
from Employees emp
join EmployeeTerritories et
on et.EmployeeID = emp.EmployeeID
join Territories t
on t.TerritoryID = et.TerritoryID
join Region r
on r.RegionID = t.RegionID
where r.RegionDescription = 'Western'
