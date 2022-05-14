-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertTrainingAndWorkShop]
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@location nvarchar(MAX),
	@date nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[TrainingAndWorkShop] ([Title], [Abbr], [Location], [Date], [UserProfileId])

	output inserted.Id

	VALUES(@title,@abbr,@location,@date,@userProfileId )
	                      
	END
