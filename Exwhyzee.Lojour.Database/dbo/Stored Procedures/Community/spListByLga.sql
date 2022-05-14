-- Get all images

Create PROCEDURE [dbo].[spListByLga]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@LgaName nvarchar(200) = null
	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Community].Id AS Id, [Community].Name, [LGA].Name AS LgaName, [LGA].Id AS LgaId
 FROM [Community]  
	LEFT JOIN [LGA] ON [Community].Id = [LGA].Id
	WHERE [LGA].Name = @LgaName
	

	AND (@searchString IS NULL OR [LGA].Name Like @searchString OR [Community].Name = @searchString)
	--set table total
	

	ORDER BY Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN