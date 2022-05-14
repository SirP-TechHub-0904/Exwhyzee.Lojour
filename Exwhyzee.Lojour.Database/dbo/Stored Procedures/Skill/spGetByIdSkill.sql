-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdSkill]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Skill] Where [Id] = @id

END
