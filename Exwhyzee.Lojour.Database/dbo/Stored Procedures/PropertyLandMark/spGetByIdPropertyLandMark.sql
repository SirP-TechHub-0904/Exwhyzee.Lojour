-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdPropertyLandMark]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[PropertyLandMark] Where [Id] = @id

END
