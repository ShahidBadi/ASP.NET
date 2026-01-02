--insert staff store procedure
create procedure MOM_Staff_Insert
	@DepartmentID int,
	@StaffName nvarchar(250),
	@MobileNo nvarchar(250),
	@EmailAddress nvarchar(250),
	@Remarks nvarchar(250)
as
begin
	insert into MOM_Staff
	(
	   DepartmentID,
	   StaffName,
	   MobileNo,
	   EmailAddress,
	   Remarks,
	   Created,
	   Modified
	)
	values(
	  @DepartmentID,
	  @StaffName,
	  @MobileNo,
	  @EmailAddress,
	  @Remarks,
	  GETDATE(),
	  GETDATE()
	 )
end;

--update staff stored procedure
go 
create procedure MOM_Staff_Update
	@StaffID int,
	@DepartmentID int,
	@StaffName nvarchar(250),
	@MobileNo nvarchar(250),
	@EmailAddress nvarchar(250),
	@Remarks nvarchar(250)
as
begin
	update MOM_Staff
	set
		DepartmentID=@DepartmentID,
		StaffName=@StaffName,
		MobileNo=@MobileNo,
		EmailAddress=@EmailAddress,
		Remarks=@Remarks,
		Modified=GETDATE()
	where StaffID=@StaffID
end;


--delete staff stored procedure
go
create procedure MOM_Staff_Delete
	@StaffID int
as
begin
	delete from MOM_Staff
	where StaffID=@StaffID
end;

--get all stored procedure
go
create procedure MOM_Staff_GetAll
as
begin
	select * from MOM_Staff;
end

--get by id stored procedure
go
create procedure MOM_Staff_GetById
 @StaffID int
as
begin
	select * from MOM_Staff where StaffID=@StaffID;
end

--get by department staff stored procedure
go
create procedure MOM_Staff_GetByDepartment
 @DepartmentID int
as
begin
  select * from MOM_Staff where DepartmentID=@DepartmentID;
end;


EXEC MOM_Staff_Insert 
    1,
    'Shahid Badi',
    '9876543210',
    'shahid@example.com',
    'Team Lead';