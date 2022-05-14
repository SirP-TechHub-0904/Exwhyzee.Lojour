CREATE PROCEDURE [dbo].[spGetByIdTour]
		@id bigint = 0 
AS
BEGIN
	SELECT Top(1) *
	FROM [dbo].[Tour] 

	
	WHERE [Tour].Id = @id
END
