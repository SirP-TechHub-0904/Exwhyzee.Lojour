-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertKindred]
	@name nvarchar(MAX),
	@communityId BIGINT
AS
BEGIN

	INSERT INTO [dbo].[Kindred] ([Name], [CommunityId])

	output inserted.Id

	VALUES(@name,@communityId )
	                      
	END
