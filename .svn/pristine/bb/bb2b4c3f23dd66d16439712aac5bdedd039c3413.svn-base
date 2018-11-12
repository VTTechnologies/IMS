-- Created by Mohammad Awez on 9 Apr 2018
if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tblLookup') 
begin
print 'Create dbo.tblLookup table'

Create Table tblLookup
(
	Id int primary key identity (0,1),
	Description varchar(100),
	CreatedDate datetime,
	Createdby varchar(50),
	ModifiedDate datetime,
	Modifiedby  varchar(50),
	status bit
)
end;
go

declare @temptable table (Description varchar(100))

Insert into @temptable(Description)values
('InActive'),
('Active'),
('Draft')

merge into [dbo].[tblLookup] as trg
using
( 
SELECT 	
	Description as descr	
	,GETDATE() as dtcreated,
	'Admin' as createdby,
	1 as status
FROM @temptable 
) as src
on trg.Description = src.descr and trg.status = src.status
when not matched by target then insert (description ,CreatedDate ,Createdby ,status)
values(src.descr,src.dtcreated,src.createdby,src.status);  
