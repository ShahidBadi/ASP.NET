--insert meeting store procedure
create procedure MOM_Meetings_Insert
	 @MeetingDate DATETIME,
    @MeetingVenueID INT,
    @MeetingTypeID INT,
    @DepartmentID INT,
    @MeetingDescription NVARCHAR(250),
    @DocumentPath NVARCHAR(250)
as
begin
	insert into MOM_Meetings(
                    MeetingDate,
                    MeetingVenueID,
                    MeetingTypeID,
                    DepartmentID,
                    MeetingDescription,
                    DocumentPath,
                    Created,
                    Modified,
                    IsCancelled
                  )
	       values(
                   @MeetingDate,
                   @MeetingVenueID,
                   @MeetingTypeID,
                   @DepartmentID,
                   @MeetingDescription,
                   @DocumentPath,
                   GETDATE(),
                    GETDATE(),
                    0
                   )
end;

--update meeting stored procedure
go
create procedure MOM_Meetings_Update
     @MeetingID int,
    @MeetingDate datetime,
    @MeetingVenueID int,
    @MeetingTypeID int,
    @DepartmentID int,
    @MeetingDescription nvarchar(250),
    @DocumentPath nvarchar(250)
as
begin
    update MOM_Meetings
    set
        MeetingDate = @MeetingDate,
        MeetingVenueID = @MeetingVenueID,
        MeetingTypeID = @MeetingTypeID,
        DepartmentID = @DepartmentID,
        MeetingDescription = @MeetingDescription,
        DocumentPath = @DocumentPath,
        Modified = GETDATE()
    where MeetingID = @MeetingID;
end;

--meeting cancel stored procedure
go
create procedure MOM_Meetings_Cancel
    @MeetingID int,
    @CancellationReason nvarchar(250)
as
begin
    update MOM_Meetings
    set 
        IsCancelled=1,
        CancellationDateTime=GETDATE(),
        CancellationReason=@CancellationReason,
        Modified=GETDATE()
    where MeetingID=@MeetingID
end;

--delete  meetings stored procedure 
go
create procedure MOM_Meetings_Delete
    @MeetingID int
as
begin
    delete from MOM_Meetings
    where MeetingID=@MeetingID
end;

--get all stored procedure
go 
create procedure MOM_Meetings_GetAll
as
begin
    select * from MOM_Meetings
end;

--get by id stored procedure
go
create procedure MOM_Meetings_GetByID
    @MeetingID int
as
begin
    select * from MOM_Meetings
    where MeetingID=@MeetingID
end;


--get by department store procedure
go  
create procedure MOM_Meetings_GetByDepartment
    @DepartmentID int
as
begin
    select * from MOM_Meetings
    where DepartmentID=@DepartmentID
end;


--execute--

select * from MOM_MeetingType

select * from MOM_Department

select * from MOM_MeetingVenue
EXEC MOM_Meetings_Insert
    '2025-02-10 10:00',
    2,
    2,
    2,
    'Quarterly Review Meeting',
    'docs/q1_review.pdf';

    EXEC MOM_Meetings_GetAll;

    
    EXEC MOM_Meetings_Update
    1,
    '2025-02-11 11:00',
    2,
    2,
    2,
    'Updated agenda',
    NULL;