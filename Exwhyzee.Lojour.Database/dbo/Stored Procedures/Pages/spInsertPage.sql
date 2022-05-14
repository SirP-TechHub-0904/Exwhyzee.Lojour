-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertPage]
	@title nvarchar(MAX),
	@pageStatus int,
	@content nvarchar(MAX),
	@pagePosition int
AS
BEGIN

	INSERT INTO [dbo].[Page] ([Title], [PageStatus], [Content], [PagePosition])

	output inserted.Id

	VALUES(@title,@pageStatus,@content,@pagePosition )
	                      
	END
