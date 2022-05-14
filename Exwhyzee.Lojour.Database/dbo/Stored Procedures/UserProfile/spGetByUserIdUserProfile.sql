-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByUserIdUserProfile]
	@userId nvarchar(MAX) = null

AS
BEGIN

	SELECT * From [dbo].[UserProfile] Where [UserId] = @userId

END
