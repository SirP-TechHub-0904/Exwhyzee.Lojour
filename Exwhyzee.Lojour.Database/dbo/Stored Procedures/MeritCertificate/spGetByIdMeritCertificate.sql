-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdMeritCertificate]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[MeritCertificate] Where [Id] = @id

END
