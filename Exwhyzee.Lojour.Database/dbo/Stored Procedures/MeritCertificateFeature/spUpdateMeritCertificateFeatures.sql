CREATE PROCEDURE [dbo].[spUpdateMeritCertificateFeatures]

	@id bigint,
	@feature nvarchar(MAX),
	@meritCertificateId bigint
AS
BEGIN
	UPDATE [dbo].[MeritCertificateFeatures] SET

	[Feature] = @feature,
	[MeritCertificateId] = @meritCertificateId


	WHERE [Id] = @id
END
