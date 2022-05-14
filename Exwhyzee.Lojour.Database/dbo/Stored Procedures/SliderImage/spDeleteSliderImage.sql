--Delete an image

CREATE PROCEDURE [dbo].[spDeleteSliderImage]
	@imageId bigInt = 0
AS
BEGIN
	Delete From [dbo].[SliderImage] Where [Id] = @imageId
END