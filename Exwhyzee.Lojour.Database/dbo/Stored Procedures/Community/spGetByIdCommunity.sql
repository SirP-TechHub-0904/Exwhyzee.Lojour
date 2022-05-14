-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdCommunity]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Community] Where [Id] = @id

END
