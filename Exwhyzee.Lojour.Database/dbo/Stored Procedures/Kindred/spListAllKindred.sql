-- Get all images

Create PROCEDURE [dbo].[spListAllKindred]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Kindred].Name, [Community].Name as Community, [Kindred].Id
	INTO #TempTableFiltered FROM [Kindred]  
	LEFT JOIN [Community] ON [Kindred].CommunityId = [Community].Id
	
	WHERE 1 = 1 
		AND (@searchString IS NULL OR [Community].Name Like @searchString)

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [Kindred] WITH(NOLOCK) 

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