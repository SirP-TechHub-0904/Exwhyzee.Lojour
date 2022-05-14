-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdJobAnalysis]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[JobAnalysis] Where [Id] = @id

END
