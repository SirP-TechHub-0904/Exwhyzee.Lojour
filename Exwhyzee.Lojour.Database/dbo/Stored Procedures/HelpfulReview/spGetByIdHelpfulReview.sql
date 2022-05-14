-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdHelpfulReview]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[HelpfulReview] Where [Id] = @id

END
