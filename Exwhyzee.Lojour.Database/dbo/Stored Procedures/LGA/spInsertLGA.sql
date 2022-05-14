-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertLGA]
	@name nvarchar(MAX),
	@stateId BIGINT
AS
BEGIN

	INSERT INTO [dbo].[LGA] ([Name], [StateId])

	output inserted.Id

	VALUES(@name,@stateId )
	                      
	END
