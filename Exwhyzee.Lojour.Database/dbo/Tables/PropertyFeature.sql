CREATE TABLE [dbo].[PropertyFeature]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(MAX) NULL, 
    [PropertyId] BIGINT NOT NULL
)
