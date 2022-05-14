-- Get all images

Create PROCEDURE [dbo].[spListAllCommunity]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Community].Name, [LGA].Name as LGA, [Community].Id
	INTO #TempTableFiltered FROM [Community]  
	LEFT JOIN [LGA] ON [Community].LGAId = [LGA].Id
	
	WHERE 1 = 1 
	AND (@searchString IS NULL OR [LGA].Name Like @searchString)

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [Community] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY Name DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN