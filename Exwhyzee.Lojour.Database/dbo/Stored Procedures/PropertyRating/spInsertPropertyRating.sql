-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertPropertyRating]

	@propertyId BIGINT,
	@rateOne bit = 0,
	@rateTwo bit = 0,
	@rateThree bit = 0,
	@rateFour bit = 0,
	@rateFive bit = 0,
	@userId nvarchar(450),
	@details nvarchar(MAX),
	@dateCreated datetime

AS
BEGIN

	INSERT INTO [dbo].[PropertyRating] 
	([PropertyId], [RateOne], [RateTwo], [RateThree],
	[RateFour], [RateFive], [UserId], [Details], [DateCreated])


	output inserted.Id

	VALUES(@propertyId,@rateOne,@rateTwo,@rateThree,@rateFour,@rateFive,
	@userId,@details,@dateCreated)
	                      
	END
