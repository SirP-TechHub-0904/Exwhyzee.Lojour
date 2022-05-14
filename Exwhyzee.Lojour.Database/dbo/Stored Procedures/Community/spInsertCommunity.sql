-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertCommunity]
	@name nvarchar(MAX),
	@lgaId BIGINT
AS
BEGIN

	INSERT INTO [dbo].[Community] ([Name], [LGAId])

	output inserted.Id

	VALUES(@name,@lgaId )
	                      
	END
