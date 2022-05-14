-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertRenderedService]
	@name nvarchar(MAX),
	@description nvarchar(MAX),

	@userProfileId bigint

AS
BEGIN

	INSERT INTO [dbo].[RenderedService] ([Name], [Description], [UserProfileId])

	output inserted.Id

	VALUES(@name,@description,@userProfileId )
	                      
	END
