--Delete an image

CREATE PROCEDURE [dbo].[spDeleteHelpfulReview]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[HelpfulReview] Where [Id] = @Id
END