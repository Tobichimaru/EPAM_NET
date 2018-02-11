use [Northwind]
go

if object_id(N'Region', N'U') is not null
execute sp_rename N'Region', N'Regions'

if col_length('Customers','FoundationDate') is null
alter table Customers
add FoundationDate datetime null