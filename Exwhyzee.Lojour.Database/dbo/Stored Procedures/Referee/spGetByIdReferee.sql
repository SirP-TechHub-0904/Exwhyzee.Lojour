-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdReferee]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[Referee] Where [Id] = @id

END
