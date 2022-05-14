CREATE PROCEDURE [dbo].[spUpdateLanguageSpoken]

	@id bigint,
@title nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[LanguageSpoken] SET

	[Title] = @title,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
