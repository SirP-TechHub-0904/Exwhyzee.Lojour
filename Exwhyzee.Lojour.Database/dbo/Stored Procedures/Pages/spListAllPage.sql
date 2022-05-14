-- Get all images

Create PROCEDURE [dbo].[spListAllPage]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT *
	INTO #TempTableFiltered FROM [Page] 

	
	WHERE 1 = 1 
	AND (@searchString IS NULL OR [Page].Title Like @searchString)

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [Page] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY Title DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN