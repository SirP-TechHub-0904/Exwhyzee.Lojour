CREATE TABLE [dbo].[RenderedService]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    
    [UserProfileId] BIGINT NOT NULL, 
   
)
