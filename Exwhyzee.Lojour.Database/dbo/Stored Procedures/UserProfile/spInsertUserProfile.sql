-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertUserProfile]
	@title nvarchar(MAX),
	@surName nvarchar(MAX),
	@FirstName nvarchar(MAX),
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

	INSERT INTO [dbo].[UserProfile] ([Title], [SurName], [FirstName], [LastName],[ContactAddress], [Country], [Description],[DateOfBirth], [DateRegistered], [UserId], [FacebookLink], [TwitterLink], [LinkedinLink],[PhotoUrl],[ComplementryCardKeywords],[LojourId],[Gender],[MaritalStatus])

	output inserted.Id

	VALUES(@title,@surName,@FirstName,@lastName,@contactAddress,@country,@description,@dateOfBirth,@dateRegistered,@userId,@facebookLink,@twitterLink,@linkedinLink,@photoUrl,@complementryCardKeywords,@lojourId,@gender,@maritalStatus)
	                      
	END

