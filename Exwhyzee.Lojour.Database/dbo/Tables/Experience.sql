CREATE TABLE [dbo].[Experience]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [ExperienceType] NVARCHAR(MAX) NULL,
    [Address] NVARCHAR(MAX) NULL,
    [StartDate] NVARCHAR(MAX) NULL,
    [EndDate] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
	[IsCurrent] BIT null, 
    [UserProfileId] BIGINT NOT NULL, 
   
)
