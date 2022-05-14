-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertReferee]
	@office nvarchar(MAX),
	@name nvarchar(MAX),
	@emailAndPhone nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[Referee] ([Office], [Name], [EmailAndPhone], [UserProfileId])

	output inserted.Id

	VALUES(@office,@name,@emailAndPhone,@userProfileId )
	                      
	END
