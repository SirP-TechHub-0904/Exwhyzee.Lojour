CREATE PROCEDURE [dbo].[spListAllProperties]
	
@status int = null,
@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@username nvarchar(50) = null,
@descriptiveStatus int = null,
@propertyStatus int = null

	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0


	SELECT [Property].Id AS Id, [PropertyName],[Amount],PropertyStatus,DescriptiveStatus,PropertyAddress,[Property].VerificationStatus,
	[Property].IdentificationNumber, SortOrder,[Property].Description,PropertyType,DateCreated, [Property].State, [Property].LGA,
	[Property].Video, [Property].PropertyLevel, [Property].HomeLocation, 
	 [Property].Community, [Property].Kindred, [Property].AgentDetails
	--[AspNetUsers].UserName AS Username
	INTO #TempTableFiltered FROM [Property]  
	--LEFT JOIN [AspNetUsers] ON [Property].Username = [AspNetUsers].UserName


	WHERE 1 = 1 
	AND (@dateStart Is NULL OR [DateCreated] >= @dateStart)
	AND (@dateEnd IS NULL OR [DateCreated] <= @dateEnd)
	AND (@searchString IS NULL OR [Property].IdentificationNumber Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].Description Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].PropertyName Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].PropertyAddress Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].PropertyType Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].State Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].LGA Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].AgentDetails Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].Community Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].Kindred Like '%' + @searchString + '%'
	OR @searchString IS NULL OR [Property].Amount Like '%' + @searchString + '%' 
	OR @searchString IS NULL OR [Property].PropertyAddress Like '%' + @searchString + '%')
	
	AND (@propertyStatus IS NULL OR [Property].PropertyStatus Like @propertyStatus)
	AND (@descriptiveStatus IS NULL OR [Property].DescriptiveStatus Like @descriptiveStatus)
	

	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [Property] WITH(NOLOCK) 

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
