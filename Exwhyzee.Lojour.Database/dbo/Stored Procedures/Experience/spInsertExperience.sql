-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertExperience]
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

	INSERT INTO [dbo].[Experience] ([Title], [ExperienceType], [Address], [StartDate], [EndDate],[Description], [IsCurrent], [UserProfileId])

	output inserted.Id

	VALUES(@title,@experienceType,@address,@startDate,@endDate,@description,@isCurrent,@userProfileId )
	                      
	END
