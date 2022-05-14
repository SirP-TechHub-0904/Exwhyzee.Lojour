-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdSliderImage]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[SliderImage] Where [Id] = @id

END
