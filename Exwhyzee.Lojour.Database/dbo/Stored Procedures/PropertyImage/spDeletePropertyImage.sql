--Delete an image

CREATE PROCEDURE [dbo].[spDeletePropertyImage]
	@imageId bigInt = 0
AS
BEGIN
	Delete From [dbo].[PropertyImage] Where [Id] = @imageId
END