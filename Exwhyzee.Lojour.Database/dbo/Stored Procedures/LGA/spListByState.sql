-- Get all images

Create PROCEDURE [dbo].[spListByState]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@stateName nvarchar(200) = null
	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [LGA].Id AS Id, [LGA].Name, [State].Name AS StateName, [State].Id AS StateId
 FROM [LGA]  
	LEFT JOIN [State] ON [LGA].Id = [State].Id
	WHERE [State].Name = @stateName
	

	AND (@searchString IS NULL OR [State].Name Like @searchString OR [LGA].Name = @searchString)
	--set table total
	

	ORDER BY Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN