-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertInterpersonalSkill]
	@title nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN

	INSERT INTO [dbo].[InterpersonalSkill] ([Title], [UserProfileId])

	output inserted.Id

	VALUES(@title,@userProfileId )
	                      
	END
