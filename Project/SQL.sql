
CREATE TABLE MOM_MeetingType (
    MeetingTypeID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingTypeName NVARCHAR(100) NOT NULL,
    Remarks NVARCHAR(100) NOT NULL
);


CREATE TABLE MOM_Department (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL
);


CREATE TABLE MOM_MeetingVenue (
    MeetingVenueID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingVenueName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL
);


CREATE TABLE MOM_Meetings (
    MeetingID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingDate DATETIME NOT NULL,
    MeetingVenueID INT NOT NULL,
    MeetingTypeID INT NOT NULL,
    DepartmentID INT NOT NULL,
    MeetingDescription NVARCHAR(250) NULL,
    DocumentPath NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,
    IsCancelled BIT NOT NULL DEFAULT 0,
    CancellationDateTime DATETIME NULL,
    CancellationReason NVARCHAR(250) NULL,

    CONSTRAINT FK_Meeting_Venue FOREIGN KEY (MeetingVenueID)
        REFERENCES MOM_MeetingVenue(MeetingVenueID),

    CONSTRAINT FK_Meeting_Type FOREIGN KEY (MeetingTypeID)
        REFERENCES MOM_MeetingType(MeetingTypeID),

    CONSTRAINT FK_Meeting_Department FOREIGN KEY (DepartmentID)
        REFERENCES MOM_Department(DepartmentID)
);


CREATE TABLE MOM_Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentID INT NOT NULL,
    StaffName NVARCHAR(50) NOT NULL,
    MobileNo NVARCHAR(20) NOT NULL,
    EmailAddress NVARCHAR(50) NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT FK_Staff_Department FOREIGN KEY (DepartmentID)
        REFERENCES MOM_Department(DepartmentID)
);


CREATE TABLE MOM_MeetingMember (
    MeetingMemberID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingID INT NOT NULL,
    StaffID INT NOT NULL,
    IsPresent BIT NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT FK_Member_Meeting FOREIGN KEY (MeetingID)
        REFERENCES MOM_Meetings(MeetingID),

    CONSTRAINT FK_Member_Staff FOREIGN KEY (StaffID)
        REFERENCES MOM_Staff(StaffID)
);


