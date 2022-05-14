-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdWorkImage]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[WorkImage] Where [Id] = @id

END
