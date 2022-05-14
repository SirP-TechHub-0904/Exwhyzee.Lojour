-- Get all images

Create PROCEDURE [dbo].[spListAllSliderImage]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [SliderImage].Id AS Id, [SliderImage].DateCreated, [SliderImage].Url, [SliderImage].ImageExtension, [SliderImage].Status
	INTO #TempTableFiltered FROM [SliderImage]  
	
	WHERE 1 = 1 

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [SliderImage] WITH(NOLOCK) 

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