CREATE PROCEDURE [dbo].[spGetByIdProperty]
		@id bigint = 0 
AS
BEGIN
	SELECT Top(1) [Property].Id AS Id, [Property].PropertyName, [Property].Amount, [Property].PropertyStatus, 
	[Property].DescriptiveStatus,
	[Property].PropertyAddress, [Property].VerificationStatus, [AspNetUsers].UserName as Username,
	[Property].IdentificationNumber, [PropertyRating].RateOne, [PropertyRating].RateTwo, [PropertyRating].RateThree
	, [PropertyRating].RateFour, [PropertyRating].RateFive, [Property].SortOrder,
	[Property].Description, [Property].AgentDetails, [Property].Longitude, [Property].Latitude, [Property].PropertyProfile, 
	[Property].PropertyType, [Property].DateCreated, [Property].State, [Property].LGA, [Property].Community, [Property].Video,
	[Property].Kindred, [Property].PropertyLevel, [Property].MapLink, [Property].HomeLocation As Position
	 FROM [dbo].[Property] 
	LEFT JOIN [AspNetUsers] ON [Property].Username = [AspNetUsers].UserName
	LEFT JOIN [PropertyRating] on [Property].Id = [PropertyRating].PropertyId

	
	WHERE [Property].Id = @id
END
