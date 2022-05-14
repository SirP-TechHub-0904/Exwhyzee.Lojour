--Delete an image

CREATE PROCEDURE [dbo].[spDeleteUserProfile]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[UserProfile] Where [Id] = @Id
END