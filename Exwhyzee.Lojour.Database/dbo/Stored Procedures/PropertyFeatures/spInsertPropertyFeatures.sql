-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertPropertyFeatures]
	@name nvarchar(MAX),
	@propertyId BIGINT

AS
BEGIN

	INSERT INTO [dbo].[PropertyFeature] ([Name], [PropertyId])

	output inserted.Id

	VALUES(@name,@propertyId )
	                      
	END
