-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertJobAnalysis]
	@title nvarchar(MAX),
	@count nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN

	INSERT INTO [dbo].[JobAnalysis] ([Title], [Count], [UserProfileId])

	output inserted.Id

	VALUES(@title,@count,@userProfileId )
	                      
	END
