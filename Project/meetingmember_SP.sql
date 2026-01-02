--insert meeting member stored procedure
GO

CREATE PROCEDURE MOM_MeetingMember_Insert
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250)
AS
BEGIN
    INSERT INTO MOM_MeetingMember (MeetingID, StaffID, IsPresent, Remarks, Created, Modified)
    VALUES (@MeetingID, @StaffID, @IsPresent, @Remarks, GETDATE(), GETDATE());
END;





--update meeting member stored procedure--
go
create procedure MOM_MeetingMember_Update
    @MeetingMemberID INT,
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250)
as 
begin
    update MOM_MeetingMember
    set
        MeetingID=@MeetingID,
        StaffID=@StaffID,
        IsPresent=@IsPresent,
        Remarks=@Remarks,
        Modified=GETDATE()
    where MeetingMemberID=@MeetingMemberID
end;



--delete meeting member stored procedure--
go
create procedure MOM_MeetingMember_Delete
    @MeetingMemberID INT
as
begin
    delete from MOM_MeetingMember
    where MeetingMemberID = @MeetingMemberID;
end;


---getall meeting member stored procedure
go
create procedure MOM_MeetingMember_GetAll
as
begin
        select * from MOM_MeetingMember
end;

--get by id meeting member stored procedure
go 
create procedure MOM_MeetingMember_GetById
@MeetingMemberID int
as 
begin
    select * from MOM_MeetingMember
    WHERE MeetingMemberID=@MeetingMemberID;
end;

EXEC MOM_MeetingMember_GetAll

EXEC MOM_MeetingMember_Insert
    @MeetingID = 1,
    @StaffID = 101,
    @IsPresent = 1,
    @Remarks = N'Attended the meeting';