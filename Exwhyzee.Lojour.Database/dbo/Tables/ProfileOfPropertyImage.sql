CREATE TABLE [dbo].[ProfileOfPropertyImage]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PropertyId] BIGINT NOT NULL, 
    [Url] NVARCHAR(MAX) NOT NULL,
	[DateCreated] datetime not null,
	[ImageExtension] nvarchar(10) null,
	[Status] int null,
	[IsDefault] bit null
)
