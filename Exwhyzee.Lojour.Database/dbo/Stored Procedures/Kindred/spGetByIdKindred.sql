-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdKindred]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Kindred] Where [Id] = @id

END
