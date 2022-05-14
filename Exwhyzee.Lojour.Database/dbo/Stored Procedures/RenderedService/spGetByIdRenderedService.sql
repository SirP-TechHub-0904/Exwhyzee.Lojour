-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdRenderedService]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[RenderedService] Where [Id] = @id

END
