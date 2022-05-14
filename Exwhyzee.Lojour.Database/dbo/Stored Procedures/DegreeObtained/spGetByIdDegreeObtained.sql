-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdDegreeObtained]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[DegreeObtained] Where [Id] = @id

END
