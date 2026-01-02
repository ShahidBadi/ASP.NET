
--insert meeting type store procedure
create procedure MOM_MeetingType_Insert
	@MeetingTypeName nvarchar(250),
	@Remarks nvarchar(250)
as 
begin
	insert into MOM_MeetingType(MeetingTypeName,Remarks)
	values(@MeetingTypeName,@Remarks)
end

--update meeting type store procedure
go
create procedure MOM_MeetingType_Update
	@MeetingTypeID int,
	@MeetingTypeName nvarchar(250),
	@Remarks nvarchar(250)
as 
begin
	update MOM_MeetingType
	set 
		MeetingTypeName=@MeetingTypeName,
		Remarks=@Remarks
	where MeetingTypeID=@MeetingTypeID
end;

--delete meeting type store procedure
go 
create procedure MOM_MeetingType_delete
	@MeetingTypeID int
as
begin
	delete from MOM_MeetingType
	where MeetingTypeID=@MeetingTypeID
end;

--get all meeting type store procedure
go 
create procedure MOM_MeetingType_GetAll
as 
begin
	select * from MOM_MeetingType;
end;

--get by id meeting type stored procedure
go 
create procedure MOM_MeetingType_GetByID
	@MeetingTypeID int
 as
 begin
	select * from MOM_MeetingType
	where MeetingTypeID=@MeetingTypeID
end;


--execute--

EXEC MOM_MeetingType_Insert 
    'Weekly Meeting',
    'Regular weekly discussion';

select * from MOM_MeetingType


EXEC MOM_MeetingType_Update 
    1,
    'Monthly Meeting',
    'Management review';


EXEC MOM_MeetingType_GetById 1;

EXEC MOM_MeetingType_GetAll;


EXEC MOM_MeetingType_Delete 1;