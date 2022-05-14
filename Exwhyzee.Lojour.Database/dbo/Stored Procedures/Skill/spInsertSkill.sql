-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertSkill]
	@title nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN

	INSERT INTO [dbo].[Skill] ([Title], [UserProfileId])

	output inserted.Id

	VALUES(@title,@userProfileId)
	                      
	END
