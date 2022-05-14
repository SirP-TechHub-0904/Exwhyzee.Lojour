CREATE PROCEDURE [dbo].[spUpdateReferee]

	@id bigint,
	@office nvarchar(MAX),
	@name nvarchar(MAX),
	@emailAndPhone nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[Referee] SET

	[Office] = @office,
	[Name] = @name,
	[EmailAndPhone] = @emailAndPhone,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
