-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdLGA]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[LGA] Where [Id] = @id

END
