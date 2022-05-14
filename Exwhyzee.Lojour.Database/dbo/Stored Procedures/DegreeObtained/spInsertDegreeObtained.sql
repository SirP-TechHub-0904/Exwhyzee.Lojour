-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertDegreeObtained]
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@date nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[DegreeObtained] ([Title], [Abbr], [Date], [UserProfileId])

	output inserted.Id

	VALUES(@title,@abbr,@date,@userProfileId )
	                      
	END
