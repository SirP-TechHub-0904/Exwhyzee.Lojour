-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdLanguageSpoken]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[LanguageSpoken] Where [Id] = @id

END
