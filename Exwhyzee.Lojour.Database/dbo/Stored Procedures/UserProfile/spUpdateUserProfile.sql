CREATE PROCEDURE [dbo].[spUpdateUserProfile]

	@id bigint,
@title nvarchar(MAX),
	@surName nvarchar(MAX),
	@firstName nvarchar(MAX),
	@lastName nvarchar(MAX),
	@contactAddress nvarchar(MAX),
	@country nvarchar(MAX),
	@description nvarchar(MAX),
	@dateOfBirth datetime,
	@dateRegistered datetime,
	@userId NVARCHAR(50),
	@facebookLink nvarchar(MAX),
	@twitterLink nvarchar(MAX),
	@linkedinLink nvarchar(MAX),
	@photoUrl nvarchar(MAX),
	@complementryCardKeywords nvarchar(MAX),
	@lojourId nvarchar(MAX),
	@gender nvarchar(MAX),
	@maritalStatus nvarchar(MAX)
AS
BEGIN
	UPDATE [dbo].[UserProfile] SET

	[Title] = @title,
	[SurName] = @surName,
	[FirstName] = @firstName,
	[LastName] = @lastName,
	[ContactAddress] = @contactAddress,
	[Country] = @country,
	[Description] = @description,
	[DateOfBirth] = @dateOfBirth,
	[DateRegistered] = @dateRegistered,
	[UserId] = @userId,
	[FacebookLink] = @facebookLink,
	[TwitterLink] = @twitterLink,
	[LinkedinLink] = @linkedinLink,
	[PhotoUrl] = @photoUrl,
	[ComplementryCardKeywords] = @complementryCardKeywords,
	[LojourId] = @lojourId,
	[Gender]= @gender,
	[MaritalStatus] = @maritalStatus

	WHERE [Id] = @id
END
