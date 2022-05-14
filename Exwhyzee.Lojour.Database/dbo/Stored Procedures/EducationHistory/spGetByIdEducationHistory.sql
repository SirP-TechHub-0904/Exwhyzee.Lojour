-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdEducationHistory]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[EducationHistory] Where [Id] = @id

END
