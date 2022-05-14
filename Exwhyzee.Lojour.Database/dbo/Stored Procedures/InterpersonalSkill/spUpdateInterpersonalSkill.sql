CREATE PROCEDURE [dbo].[spUpdateInterpersonalSkill]

	@id bigint,
@title nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN
	UPDATE [dbo].[InterpersonalSkill] SET

	[Title] = @title,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
