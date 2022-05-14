CREATE PROCEDURE [dbo].[spUpdateMembershipOfLearneredSociety]

	@id bigint,
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@userProfileId bigint

AS
BEGIN
	UPDATE [dbo].[MembershipOfLearneredSociety] SET

	[Title] = @title,
	[Abbr] = @abbr,
	[UserProfileId] = @userProfileId


	WHERE [Id] = @id
END
