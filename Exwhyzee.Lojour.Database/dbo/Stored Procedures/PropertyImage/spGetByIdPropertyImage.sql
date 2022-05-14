-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdPropertyImage]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[PropertyImage] Where [Id] = @id

END
