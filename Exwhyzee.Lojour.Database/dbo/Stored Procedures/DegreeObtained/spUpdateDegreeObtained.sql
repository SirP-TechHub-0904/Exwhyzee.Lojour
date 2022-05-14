CREATE PROCEDURE [dbo].[spUpdateDegreeObtained]

	@id bigint,
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@date nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[DegreeObtained] SET

	[Title] = @title,
	[Abbr] = @abbr,
	[Date] = @date,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
