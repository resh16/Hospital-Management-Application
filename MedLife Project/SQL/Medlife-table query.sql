create Database MedLife



use MedLife


-- To generate GUID
 -- select newid() 

------------------Identity Tables --------------------------------

Create table AppUser(
Id UNIQUEIDENTIFIER PRIMARY KEY not null default NEWID(),

UserName nvarchar(256)  null,
NormalizedUserName nvarchar(256),
Email nvarchar(256),
NormalizedEmail nvarchar(256),
EmailConfirmed bit not null,
PasswordHash nvarchar(max),
SecurityStamp nvarchar(max),
ConcurrencyStamp nvarchar(max),
PhoneNumber nvarchar(max),
PhoneNumberConfirmed bit ,
TwoFactorEnabled bit not null ,
LockoutEnd datetimeoffset(7),
LockoutEnabled bit not null,
AcessFailedCount int not null,
Name nvarchar(256) not null,
Age int not null,
Gender nvarchar(10) not null,
UserRole nvarchar(50) 
);









create table AppRoles(

Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
Name nvarchar(256),
NormalizedName nvarchar(256),
ConcurrencyStamp nvarchar(max)
);


create table AppUserRoles(

UserId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
RoleId Uniqueidentifier foreign key references AppRoles(Id) not null,
PRIMARY KEY (UserId, RoleId)

);


Create table AppUserLogins (

LoginProvider uniqueIdentifier  not null,
ProviderKey uniqueIdentifier not null,
ProviderDisplayName nvarchar(max),
UserId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
PRIMARY KEY (LoginProvider, ProviderKey)

);

Create table AppUserTokens (

UserId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
LoginProvider nvarchar(450)  not null,
Name nvarchar(450) not null ,
Value nvarchar(max),
PRIMARY KEY (UserId, LoginProvider,Name)


);

Create table AppRoleClaims (
Id int primary key not null,
RoleId uniqueIdentifier foreign key references AppRoles(Id) not null, 
ClaimType nvarchar(max) ,
ClaimValue nvarchar(max)

);


create table AppUserClaims(

Id int primary key not null,
UserId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
ClaimType nvarchar(max),
ClaimValue nvarchar(max)

);

-------------------project tables -----------------------

create table Departments(

Id int identity(1,1) primary key not null,
Name nvarchar(200) not null
);



create table Doctors(

Id UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
Qualification nvarchar(300) not null,
Experience int not null,
Image nvarchar(300) not null,
UniqueImageName nvarchar(500)  not null,
DepartmentId int foreign key references Departments(Id) not null,
CreatedAt datetime default Current_timestamp not null,
ModifiedAt datetime ,
CreatedBy UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
ModifiedBy UNIQUEIDENTIFIER foreign key references AppUser(Id) 

);

Alter table Doctors
Add constraint pk_doctors 
primary key (Id)



create table HealthProblems (

Id int identity(1,1) primary key not null,
Name nvarchar(300) not null

);

create table AppoinmentBooking (

Id int identity(1,1) primary key not null,
PatientId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
DoctorId UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
AppointmentDateTime datetime not null,
HealthProblemId int foreign key references HealthProblems(Id) not null,
others nvarchar(500) ,
Priscription nvarchar(300),
StatusId int foreign key references Status(Id) not null,
CreatedAt datetime default Current_timestamp not null,
ModifiedAt datetime ,
CreatedBy UNIQUEIDENTIFIER foreign key references AppUser(Id) not null,
ModifiedBy UNIQUEIDENTIFIER foreign key references AppUser(Id) 

);








create table Status(

Id int identity(1,1) primary key not null,
Name nvarchar(50) not null
);

--------------------------------------
create table Appoinmentstatus (

Id int identity(1,1) primary key not null,
AppoinmentId int foreign key references AppoinmentBooking(Id) not null,
StatusId int foreign key references Status(Id) not null,


);

--------------Stored Procedure ----------------------------

Alter procedure usp_GetAllDoctors 

As
Begin try

select a.Name as DoctorName, Email,Age,Gender, d2.Name as Department,Qualification,Experience,UniqueImageName
from AppUser a 
Inner join Doctors d on d.Id = a.Id
Inner join Departments d2 on d2.Id = d.DepartmentId
where a.UserRole = 'Doctor'


End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;


Exec usp_GetAllDoctors 
------------------------

create procedure usp_GetAllPatients 
As
Begin try

Select Name,Email,Age,Gender
from AppUser
where UserRole = 'Patient'




End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;



---------------------------------

create procedure usp_GetAllConfirmedPatients (@DoctorId uniqueidentifier)
As
Begin try

Select a.Name,Email,Age,Gender,AppointmentOn,h.Name as HealthProblem,others,s.Name as Status
from AppUser a 
inner join AppoinmentBooking ab on ab.PatientId = a.Id
inner join HealthProblems h on h.Id = ab.HealthProblemId
inner join Status s on s.Id = ab.StatusId

where a.Id = @DoctorId and s.Id = 2



End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;

Exec usp_GetAllConfirmedPatients 'A9B74184-9FB6-4841-A5A1-08D9C763981E'

------------
Alter procedure usp_GetAllPendingPatients (@DoctorId uniqueidentifier)
As
Begin try

Select a.Name,Email,Age,Gender,AppointmentOn,h.Name as HealthProblem,others,s.Name as Status
from AppUser a 
inner join AppoinmentBooking ab on ab.PatientId = a.Id
inner join HealthProblems h on h.Id = ab.HealthProblemId
inner join Status s on s.Id = ab.StatusId

where ab.DoctorId = @DoctorId and ab.StatusId = 1



End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;
---------------
Exec usp_GetAllPendingPatients 'A9B74184-9FB6-4841-A5A1-08D9C763981E'

create procedure usp_ModifyStatus(@PatientId uniqueidentifier,@StatusId int,@Priscription nvarchar(300))
As
Begin try

Update AppoinmentBooking
set StatusId = @StatusId, Priscription = @Priscription
where PatientId = @PatientId

End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;

---------
create procedure usp_PatientDetails(@PatientId uniqueidentifier)
As
Begin try

Select a.Name,Email,Age,Gender,AppointmentOn,h.Name as HealthProblem,others,s.Name as Status
from AppUser a 
inner join AppoinmentBooking ab on ab.PatientId = a.Id
inner join HealthProblems h on h.Id = ab.HealthProblemId
inner join Status s on s.Id = ab.StatusId
where PatientId = @PatientId

End try
BEGIN CATCH
-- REPORTING THE EXCEPTION
SELECT ERROR_NUMBER() AS ERRORNO,ERROR_LINE() AS ERRORLINE,ERROR_MESSAGE() AS ERRORMSG,
ERROR_PROCEDURE() AS ERRORPROCEDURE,ERROR_SEVERITY() AS ERRORSEVERITY
END CATCH;
Go;



