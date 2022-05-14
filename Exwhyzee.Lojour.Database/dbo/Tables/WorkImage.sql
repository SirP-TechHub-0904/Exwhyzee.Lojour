CREATE TABLE [dbo].[WorkImage]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserProfileId] BIGINT NOT NULL, 
    [Url] NVARCHAR(MAX) NOT NULL,
	[Status] int null,
	[IsDefault] bit null, 
    [Title] NVARCHAR(MAX) NULL, 
    [Address] NVARCHAR(MAX) NULL
)
