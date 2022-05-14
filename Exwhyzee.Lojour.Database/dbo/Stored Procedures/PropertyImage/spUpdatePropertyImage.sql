CREATE PROCEDURE [dbo].[spUpdatePropertyImage]

	@id bigint,
@url nvarchar(MAX),	
	@propertyId bigint,
	@dateCreated dateTime,
	@imageExtension nvarchar(450),
	@status int,
	@isDefault bit
AS
BEGIN
	UPDATE [dbo].[PropertyImage] SET

	[Url] = @url,
	[PropertyId] = @propertyId,
	[DateCreated] = @dateCreated,
	[ImageExtension] = @imageExtension,
	[Status] = @status,
	[IsDefault] = @isDefault

	WHERE [Id] = @id
END
