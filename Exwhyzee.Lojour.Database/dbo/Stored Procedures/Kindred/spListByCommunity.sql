-- Get all images

Create PROCEDURE [dbo].[spListByCommunity]	



@dateStart datetime = null,
@dateEnd datetime = null,
@startIndex int = 0,
@count int = 2147483647,
@searchString nvarchar(200) = null,
@communityName nvarchar(200) = null
	
AS

	DECLARE @FilteredCount INT = 0
	DECLARE @TotalCount INT = 0

	SELECT [Kindred].Id AS Id, [Kindred].Name, [Community].Name AS CommunityName, [Community].Id AS CommunityId
 FROM [Kindred]  
	LEFT JOIN [Community] ON [Kindred].Id = [Community].Id
	WHERE [Community].Name = @communityName
	

	AND (@searchString IS NULL OR [Community].Name Like @searchString OR [Kindred].Name = @searchString)
	--set table total
	

	ORDER BY Id DESC
	OFFSET @startIndex ROWS 
	FETCH NEXT @count ROWS ONLY

	--SELECT Summary Result
	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	RETURN