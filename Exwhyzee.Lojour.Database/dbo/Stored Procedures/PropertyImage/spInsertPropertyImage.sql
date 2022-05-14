-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertPropertyImage]
	@url nvarchar(MAX),	
	@propertyId bigint,
	@dateCreated dateTime,
	@imageExtension nvarchar(450),
	@status int,
	@isDefault bit
AS
BEGIN

	INSERT INTO [dbo].[PropertyImage] ([PropertyId],[Url],[DateCreated], [ImageExtension],[Status], [IsDefault])

	output inserted.Id

	VALUES(@propertyId,@url,@dateCreated,@imageExtension,@status,@isDefault )
	                      
	END
