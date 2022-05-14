CREATE PROCEDURE [dbo].[spListAllTour]
	
@status int = null,
@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null


AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0


	SELECT *
	--[AspNetUsers].UserName AS Username
	INTO #TempTableFiltered FROM [Tour]  
	--LEFT JOIN [AspNetUsers] ON [Property].Username = [AspNetUsers].UserName


	WHERE 1 = 1 
	AND (@dateStart Is NULL OR [Date] >= @dateStart)
	AND (@dateEnd IS NULL OR [Date] <= @dateEnd)
	


	--set table total
	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM [Tour] WITH(NOLOCK) 

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
