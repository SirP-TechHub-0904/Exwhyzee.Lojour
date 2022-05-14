CREATE TABLE [dbo].[UserProfile]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [SurName] NVARCHAR(MAX) NULL,
    [FirstName] NVARCHAR(MAX) NULL,
    [LastName] NVARCHAR(MAX) NULL,
    [ContactAddress] NVARCHAR(MAX) NULL,
    [Country] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
	[DateOfBirth]          DATETIME2 (7)      NOT NULL,
    [DateRegistered]       DATETIME2 (7)      NOT NULL, 
    [UserId] NVARCHAR(50) NULL, 
    [MaritalStatus] NVARCHAR(MAX) NULL, 
    [Gender] NVARCHAR(MAX) NULL, 
    [State] NVARCHAR(MAX) NULL,
    [FacebookLink] NVARCHAR(MAX) NULL,
    [TwitterLink] NVARCHAR(MAX) NULL,
    [LinkedinLink] NVARCHAR(MAX) NULL, 
    [PhotoUrl] NVARCHAR(MAX) NULL, 
    [ComplementryCardKeywords] NVARCHAR(MAX) NULL, 
    [LojourId] NVARCHAR(MAX) NULL,
	
)
