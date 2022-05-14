-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertMeritCertificate]
	@title nvarchar(MAX),
	@startDate nvarchar(MAX),
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[MeritCertificate] ([Title], [StartDate], [UserProfileId])

	output inserted.Id

	VALUES(@title,@startDate,@userProfileId )
	                      
	END
