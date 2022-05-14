CREATE TABLE [dbo].[RequestProperty]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PropertyName] NVARCHAR(MAX) NULL,
    [PhoneNumber] NVARCHAR(MAX) NULL,
    [Email] NVARCHAR(MAX) NOT NULL,
    [ListType] NVARCHAR(MAX) NULL,
    [Category] NVARCHAR(MAX) NULL,
    [Location] NVARCHAR(MAX) NULL,
    [LandMark] NVARCHAR(MAX) NULL,
    [Features] NVARCHAR(MAX) NULL,
    [AmountRange] NVARCHAR(MAX) NULL,
    [AlertType] NVARCHAR(MAX) NULL,
    [AlertDuration] NVARCHAR(MAX) NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [RequestId] NVARCHAR(MAX) NULL
)
