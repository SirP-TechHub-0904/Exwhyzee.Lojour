CREATE TABLE [dbo].[EducationHistory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [SchoolAttended] NVARCHAR(MAX) NULL,
    [Course] NVARCHAR(MAX) NULL,
    [StartDate] NVARCHAR(MAX) NULL,
    [EndDate] NVARCHAR(MAX) NULL,
    [Grade] NVARCHAR(MAX) NULL,
	[IsCurrent] BIT null, 
    [UserProfileId] BIGINT NOT NULL, 
   
)
