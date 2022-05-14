-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertMeritCertificateFeatures]
	@feature nvarchar(MAX),
	@meritCertificateId bigint

AS
BEGIN

	INSERT INTO [dbo].[MeritCertificateFeatures] ([Feature], [MeritCertificateId])

	output inserted.Id

	VALUES(@feature,@meritCertificateId )
	                      
	END
