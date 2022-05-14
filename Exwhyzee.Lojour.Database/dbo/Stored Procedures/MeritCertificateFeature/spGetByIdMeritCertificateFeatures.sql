-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdMeritCertificateFeatures]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[MeritCertificateFeatures] Where [Id] = @id

END
