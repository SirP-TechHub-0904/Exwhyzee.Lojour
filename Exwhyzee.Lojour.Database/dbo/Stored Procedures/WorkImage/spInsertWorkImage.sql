-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertWorkImage]
	
	@userProfileId bigint,
	@url nvarchar(MAX),
	@status int,
	@isDefault bit,
	@title nvarchar(MAX),
	@address nvarchar(MAX)
AS
BEGIN

	INSERT INTO [dbo].[WorkImage] ([UserProfileId], [Url], [Status], [IsDefault], [Title], [Address])

	output inserted.Id

	VALUES(@userProfileId,@url,@status,@isDefault,@title,@address )
	                      
	END
	