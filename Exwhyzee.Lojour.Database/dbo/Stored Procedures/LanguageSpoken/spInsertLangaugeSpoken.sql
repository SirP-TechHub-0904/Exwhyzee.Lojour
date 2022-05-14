-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertLanguageSpoken]
	@title nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN

	INSERT INTO [dbo].[LanguageSpoken] ([Title], [UserProfileId])

	output inserted.Id

	VALUES(@title,@userProfileId )
	                      
	END
