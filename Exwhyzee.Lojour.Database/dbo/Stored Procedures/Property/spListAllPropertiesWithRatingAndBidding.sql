CREATE PROCEDURE [dbo].[spListAllPropertiesWithRatingAndBidding]
	
@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(50) = null
	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Property].Id AS Id, [Property].PropertyName, [Property].Amount, [Property].PropertyStatus,[Property].DescriptiveStatus,
	[Property].PropertyAddress,	[Property].IdentificationNumber, [PropertyRating].RateOne, [PropertyRating].RateTwo, [PropertyRating].RateThree
	, [PropertyRating].RateFour, [PropertyRating].RateFive, [Property].SortOrder, [Property].HomeLocation
	INTO #TempTableFiltered FROM [Property]  
	LEFT JOIN [AgentPropertyReview] ON [Property].Id = [AgentPropertyReview].PropertyId
	LEFT JOIN [AspNetUsers] ON [AgentPropertyReview].AgentUserId = [AspNetUsers].Id
	LEFT JOIN [PropertyRating] on [Property].Id = [PropertyRating].PropertyId

	
	 
	WHERE 1 = 1 
	AND (@dateStart Is NULL OR [Property].DateCreated >= @dateStart)
	AND (@dateEnd IS NULL OR [Property].DateCreated <= @dateEnd)
	
	AND (@searchString IS NULL OR [AspNetUsers].UserName Like @searchString OR [Property].PropertyName Like @searchString
	 OR [Property].State Like @searchString OR [Property].LGA Like @searchString OR [Property].Community Like @searchString
	  OR [Property].Kindred Like @searchString OR [Property].Amount Like @searchString OR [Property].AgentDetails Like @searchString)
	
	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [AspNetUsers] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY DatePurchased DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN
