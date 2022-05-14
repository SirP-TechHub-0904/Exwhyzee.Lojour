-- Get all images

Create PROCEDURE [dbo].[spListAllPropertyRating]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@propertyId bigint = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

SELECT [PropertyRating].DateCreated, [PropertyRating].Details, [PropertyRating].RateFive,
[PropertyRating].RateFour, [PropertyRating].RateOne, [Property].PropertyName as Property
	INTO #TempTableFiltered FROM [PropertyRating]  
	LEFT JOIN [Property] ON [PropertyRating].PropertyId = [Property].Id 
	
	WHERE 1 = 1 
	AND (@propertyId IS NULL OR [PropertyRating].PropertyId = @propertyId)
	AND (@searchString IS NULL OR [PropertyRating].Details Like @searchString )
	

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [PropertyRating] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY [PropertyRating].Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN