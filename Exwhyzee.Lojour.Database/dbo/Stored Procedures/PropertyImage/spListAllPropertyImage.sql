-- Get all images

Create PROCEDURE [dbo].[spListAllPropertyImage]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@propertyId bigint = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [PropertyImage].Id AS Id, [PropertyImage].DateCreated, [PropertyImage].Url,
	[PropertyImage].Status, [PropertyImage].IsDefault, [PropertyImage].PropertyId
	INTO #TempTableFiltered FROM [PropertyImage]  
	LEFT JOIN [Property] ON [PropertyImage].PropertyId = [Property].Id

	WHERE 1 = 1 
		AND (@propertyId IS NULL OR [PropertyImage].PropertyId = @propertyId)
	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [PropertyImage] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY DateCreated DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN