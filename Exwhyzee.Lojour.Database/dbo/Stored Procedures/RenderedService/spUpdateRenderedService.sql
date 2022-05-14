CREATE PROCEDURE [dbo].[spUpdateRenderedService]

	@id bigint,
	@name nvarchar(MAX),
	@description nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[RenderedService] SET

	[Name] = @name,
	[Description] = @description,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
