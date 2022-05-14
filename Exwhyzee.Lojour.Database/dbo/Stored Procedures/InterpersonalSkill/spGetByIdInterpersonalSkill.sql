-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdInterpersonalSkill]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[InterpersonalSkill] Where [Id] = @id

END
