CREATE TABLE [dbo].[MeritCertificateFeatures]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Feature] NVARCHAR(MAX) NOT NULL,
   
    [MeritCertificateId] BIGINT NOT NULL, 
   
)
