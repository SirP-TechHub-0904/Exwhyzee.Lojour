--Delete an image

CREATE PROCEDURE [dbo].[spDeleteMeritCertificateFeatures]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[MeritCertificateFeatures] Where [Id] = @Id
END