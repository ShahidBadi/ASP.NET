--insert department stored procedure
create procedure MOM_Department_Insert
 @DepartmentName nvarchar(250)
as
begin
 insert into MOM_Department(DepartmentName,Created,Modified)
	values(@DepartmentName,GETDATE(),GETDATE());
end;

--update department store procedure
go
create procedure MOM_Department_Update
	@DepartmentID int,
	@DepartmentName nvarchar(250)
as
begin
	update MOM_Department
	set 
		DepartmentName=@DepartmentName,
		Modified=GETDATE()
	where DepartmentID=@DepartmentID
end;

--delete department stored procedure
go
create procedure MOM_Department_Delete
	@DepartmentID int
as
begin
	delete from MOM_Department
	where DepartmentID=@DepartmentID
end;


--getall department store procedure
go
create procedure MOM_Department_GetAll
as
begin
	select * from MOM_Department;
end;

--get by id department store procedure
go 
create procedure MOM_Department_GetByID
 @DepartmentID int
as
begin
 select * from MOM_Department
	where DepartmentID=@DepartmentID
end;


--execute

EXEC MOM_Department_Insert 'Human Resources';

EXEC MOM_Department_GetAll;

EXEC MOM_Department_Update 1, 'IT Department';

EXEC MOM_Department_GetById 1;


EXEC MOM_Department_Delete 1;