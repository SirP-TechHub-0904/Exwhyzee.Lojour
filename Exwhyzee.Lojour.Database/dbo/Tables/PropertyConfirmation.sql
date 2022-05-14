CREATE TABLE [dbo].[PropertyConfirmation]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PropertyId] BIGINT NOT NULL, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [ConfirmationNote] NVARCHAR(MAX) NULL,
	[DateCreated] datetime not null,
)
