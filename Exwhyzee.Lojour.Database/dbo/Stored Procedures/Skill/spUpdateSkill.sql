CREATE PROCEDURE [dbo].[spUpdateSkill]

	@id bigint,
@title nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN
	UPDATE [dbo].[Skill] SET

	[Title] = @title,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
