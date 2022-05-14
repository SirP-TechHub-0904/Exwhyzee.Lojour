-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdState]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[State] Where [Id] = @id

END
