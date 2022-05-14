CREATE PROCEDURE [dbo].[spUpdateJobAnalysis]

	@id bigint,
@title nvarchar(MAX),
@count nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[JobAnalysis] SET

	[Title] = @title,
	[Count] = @count,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
