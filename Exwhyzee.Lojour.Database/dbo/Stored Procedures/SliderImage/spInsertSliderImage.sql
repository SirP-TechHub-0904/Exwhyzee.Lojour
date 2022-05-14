-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertSliderImage]
	@url nvarchar(299),	
	@dateCreated dateTime,
	@imageExtension nvarchar(50),
	@status int
AS
BEGIN

	INSERT INTO [dbo].[SliderImage] ([Url],[DateCreated],[ImageExtension],[Status])

	output inserted.Id

	VALUES(@url,@dateCreated,@imageExtension,@status )
	                      
	END
