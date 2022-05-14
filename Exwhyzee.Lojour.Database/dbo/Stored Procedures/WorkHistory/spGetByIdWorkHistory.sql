-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdWorkHistory]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[WorkHistory] Where [Id] = @id

END
