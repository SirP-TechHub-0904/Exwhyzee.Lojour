-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdPropertyRating]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[PropertyRating] Where [Id] = @id

END
