-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertPropertyLandMark]
	@name nvarchar(MAX),
	@distance NVARCHAR(450), 
    @landMarkType NVARCHAR(450), 
	@propertyId BIGINT

AS
BEGIN

	INSERT INTO [dbo].[PropertyLandMark] ([Name], [Distance], [LandMarkType], [PropertyId])

	output inserted.Id

	VALUES(@name,@distance,@landMarkType,@propertyId )
	                      
	END

