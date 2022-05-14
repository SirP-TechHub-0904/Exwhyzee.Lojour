CREATE PROCEDURE [dbo].[spGetByIdRequestProperty]
		@id bigint = 0 
AS
BEGIN
	SELECT Top(1) *
	FROM [dbo].[RequestProperty] 

	
	WHERE [RequestProperty].Id = @id
END
