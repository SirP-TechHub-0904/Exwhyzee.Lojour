CREATE PROCEDURE [dbo].[spUpdateMeritCertificate]

	@id bigint,
@title nvarchar(MAX),
	@startDate nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[MeritCertificate] SET

	[Title] = @title,
	[StartDate] = @startDate,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
