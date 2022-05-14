-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertState]
	@name nvarchar(MAX)
AS
BEGIN

	INSERT INTO [dbo].[State] ([Name])

	output inserted.Id

	VALUES(@name )
	                      
	END
