--Delete an image

CREATE PROCEDURE [dbo].[spDeleteMeritCertificate]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[MeritCertificate] Where [Id] = @Id
END