-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdExperience]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Experience] Where [Id] = @id

END
