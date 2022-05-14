CREATE TABLE [dbo].[Page]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NOT NULL,
	[PageStatus] int null, 
    [Content] NVARCHAR(MAX) NULL, 
    [PagePosition] INT NULL,
)
