	CREATE PROCEDURE [dbo].[spListAllPropertiesByUserId]
	
@status int = null,
@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@username nvarchar(50) = null
	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Property].Id AS Id, [Property].PropertyName, [Property].Amount, [Property].PropertyStatus, 
	[Property].DescriptiveStatus,
	[Property].PropertyAddress, [Property].VerificationStatus,
	[Property].IdentificationNumber, [PropertyRating].RateOne, [PropertyRating].RateTwo, [PropertyRating].RateThree
	, [PropertyRating].RateFour, [PropertyRating].RateFive, [Property].SortOrder,
	[Property].Description, [Property].AgentDetails, [Property].Longitude, [Property].Latitude, [Property].PropertyProfile, 
	[Property].PropertyType, [Property].DateCreated, [Property].State, [Property].LGA, [Property].Community,
	[Property].Kindred, [Property].HomeLocation, [AspNetUsers].UserName as UserName
	
	INTO #TempTableFiltered FROM [Property]  
	LEFT JOIN [AspNetUsers] ON [Property].Username = [AspNetUsers].UserName
	LEFT JOIN [PropertyRating] on [Property].Id = [PropertyRating].PropertyId
	 
	WHERE [AspNetUsers].UserName = @username

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [AspNetUsers] WITH(NOLOCK) 

	--set filtered count
	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM #TempTableFiltered

	--Select table result
	SELECT * FROM #TempTableFiltered
	ORDER BY Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN
