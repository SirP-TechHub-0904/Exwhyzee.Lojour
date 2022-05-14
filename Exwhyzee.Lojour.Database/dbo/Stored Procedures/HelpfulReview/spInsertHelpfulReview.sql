-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertHelpfulReview]
	
	@propertyReviewId BIGINT,
	@userId nvarchar(450),
	@dateCreated datetime
AS
BEGIN

	INSERT INTO [dbo].[HelpfulReview] ([PropertyReviewId], [UserId], [DateCreated])

	output inserted.Id

	VALUES(@propertyReviewId, @userId, @dateCreated )
	                      
	END
