CREATE PROCEDURE [dbo].[spUpdateWorkImage]

	@id bigint,
	@userProfileId bigint,
	@url nvarchar(MAX),
	@status int,
	@isDefault bit,
	@title nvarchar(MAX),
	@address nvarchar(MAX)
AS
BEGIN
	UPDATE [dbo].[WorkImage] SET

	[UserProfileId] = @userProfileId,
	[Url] = @url,
	[Status] = @status,
	[IsDefault] = @isDefault,
[Title] = @title, 
[Address] = @address

	WHERE [Id] = @id
END

