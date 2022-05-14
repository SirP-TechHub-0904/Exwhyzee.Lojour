CREATE PROCEDURE [dbo].[spUpdateTrainingAndWorkShop]

	@id bigint,
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@location nvarchar(MAX),
	@date nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[TrainingAndWorkShop] SET

	[Title] = @title,
	[Abbr] = @abbr,
	[Location] = @location,
	[Date] = @date,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
