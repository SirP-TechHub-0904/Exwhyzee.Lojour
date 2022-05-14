-- Get all images

Create PROCEDURE [dbo].[spListAllHelpfulReview]	

@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@propertyId bigint = null,
@userId nvarchar(450) = null

AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

SELECT [HelpfulReview].DateCreated, [Property].PropertyName as Property, 
[AspNetUsers].UserName
	INTO #TempTableFiltered FROM [HelpfulReview]  
	LEFT JOIN [Property] ON [HelpfulReview].PropertyReviewId = [Property].Id 
	LEFT JOIN [AspNetUsers] ON [HelpfulReview].UserId = [AspNetUsers].Id 
	
	WHERE 1 = 1 
	AND (@propertyId IS NULL OR [HelpfulReview].PropertyReviewId = @propertyId)
	AND (@userId IS NULL OR [HelpfulReview].UserId = @userId)

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [HelpfulReview] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY [HelpfulReview].Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN