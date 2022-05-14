-- Get all images

Create PROCEDURE [dbo].[spListAllPropertyLandMark]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@propertyId bigint = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

SELECT [PropertyLandMark].Name, [PropertyLandMark].Id, [Property].PropertyName as Property, [PropertyLandMark].Distance, [PropertyLandMark].PropertyId as PropertyId,
[PropertyLandMark].LandMarkType
	INTO #TempTableFiltered FROM [PropertyLandMark]  
	LEFT JOIN [Property] ON [PropertyLandMark].PropertyId = [Property].Id 
	
	WHERE PropertyId = @propertyId
	

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [PropertyFeature] WITH(NOLOCK) 

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