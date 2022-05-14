-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertWorkHistory]
	@name nvarchar(MAX),
	@description nvarchar(MAX),
	@videoUrl nvarchar(MAX),
	@location nvarchar(MAX),
	@userProfileId bigint
	
AS
BEGIN

	INSERT INTO [dbo].[WorkHistory] ([Name], [Description], [VideoUrl], [Location], [UserProfileId])

	output inserted.Id

	VALUES(@name,@description,@videoUrl,@location,@userProfileId )
	                      
	END
