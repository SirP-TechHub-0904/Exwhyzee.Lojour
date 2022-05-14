CREATE TABLE [dbo].[TrainingAndWorkShop]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [Abbr] NVARCHAR(MAX) NULL,
    [Location] NVARCHAR(MAX) NULL,
    [Date] NVARCHAR(MAX) NULL,
    [UserProfileId] BIGINT NOT NULL, 
   
)
