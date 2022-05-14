-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdPropertyFeatures]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[PropertyFeature] Where [Id] = @id

END
