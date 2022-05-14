CREATE TABLE [dbo].[MembershipOfLearneredSociety]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
    [Abbr] NVARCHAR(MAX) NULL,
    [UserProfileId] BIGINT NOT NULL, 
   
)
