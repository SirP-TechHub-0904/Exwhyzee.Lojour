CREATE TABLE [dbo].[AgentPropertyReview]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PropertyId] BIGINT NOT NULL, 
    [AgentUserId] NVARCHAR(450) NOT NULL, 
    [ReviewNote] NVARCHAR(MAX) NULL,
	[DateCreated] datetime not null,
)
