CREATE TABLE [dbo].[SliderImage]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Url] NVARCHAR(MAX) NOT NULL,
	[DateCreated] datetime not null,
	[ImageExtension] nvarchar(10) null,
	[Status] int null
)
