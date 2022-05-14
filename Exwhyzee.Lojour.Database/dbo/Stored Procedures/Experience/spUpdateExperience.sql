CREATE PROCEDURE [dbo].[spUpdateExperience]

	@id bigint,
	@title nvarchar(MAX),
	@experienceType nvarchar(MAX),
	@address nvarchar(MAX),
	@startDate nvarchar(MAX),
	@endDate nvarchar(MAX),
	@description nvarchar(MAX),
	@isCurrent bit,
	@userProfileId bigint
AS
BEGIN
	UPDATE [dbo].[Experience] SET


	[Title] = @title,
	[ExperienceType] = @experienceType,
	[Address] = @address,
	[StartDate] = @startDate,
	[EndDate] = @endDate,
	[Description] = @description,
	[IsCurrent] = @isCurrent,
	[UserProfileId] = @userProfileId
	


	WHERE [Id] = @id
END
