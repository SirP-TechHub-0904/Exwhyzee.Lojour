-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertMembershipOfLearneredSociety]
	@title nvarchar(MAX),
	@abbr nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[MembershipOfLearneredSociety] ([Title], [Abbr], [UserProfileId])

	output inserted.Id

	VALUES(@title,@abbr,@userProfileId )
	                      
	END
