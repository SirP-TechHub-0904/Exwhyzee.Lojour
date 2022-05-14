-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdUserProfile]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[UserProfile] Where [Id] = @id

END
