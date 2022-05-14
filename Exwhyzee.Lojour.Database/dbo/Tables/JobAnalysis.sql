CREATE TABLE [dbo].[JobAnalysis]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [Count] NVARCHAR(MAX) NULL,

    [UserProfileId] BIGINT NOT NULL, 
   
)
