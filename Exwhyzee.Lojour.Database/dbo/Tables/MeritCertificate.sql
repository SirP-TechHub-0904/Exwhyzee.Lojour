CREATE TABLE [dbo].[MeritCertificate]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,
   
    [StartDate] NVARCHAR(MAX) NULL,

    [UserProfileId] BIGINT NOT NULL, 
   
)
