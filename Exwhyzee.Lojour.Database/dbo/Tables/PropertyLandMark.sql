CREATE TABLE [dbo].[PropertyLandMark]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(MAX) NULL, 
    [Distance] NVARCHAR(450) NULL, 
    [LandMarkType] NVARCHAR(450) NULL, 
	 [PropertyId] BIGINT NOT NULL
   
)
