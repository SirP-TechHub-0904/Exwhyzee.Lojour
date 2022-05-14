--Delete an image

CREATE PROCEDURE [dbo].[spDeletePropertyRating]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[PropertyRating] Where [Id] = @Id
END