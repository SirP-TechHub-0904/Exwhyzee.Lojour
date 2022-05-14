CREATE PROCEDURE [dbo].[spUpdateWorkHistory]

	@id bigint,
	@name nvarchar(MAX),
	@description nvarchar(MAX),
	@videoUrl nvarchar(MAX),
	@location nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN
	UPDATE [dbo].[WorkHistory] SET

	[Name] = @name,
	[Description] = @description,
	[VideoUrl] = @videoUrl,
	[Location] = @location,
	[UserProfileId] = @userProfileId

	WHERE [Id] = @id
END
