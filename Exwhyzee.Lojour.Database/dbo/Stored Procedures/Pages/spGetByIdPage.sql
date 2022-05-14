-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdPage]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Page] Where [Id] = @id

END
