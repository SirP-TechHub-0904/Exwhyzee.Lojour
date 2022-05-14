CREATE TABLE [dbo].[Kindred]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NOT NULL,
	[CommunityId] BIGINT not null,
)
