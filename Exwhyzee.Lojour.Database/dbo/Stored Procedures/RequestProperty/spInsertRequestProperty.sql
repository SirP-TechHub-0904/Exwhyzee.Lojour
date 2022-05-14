CREATE PROCEDURE [dbo].[spInsertRequestProperty]

		@propertyName nvarchar(MAX),
		@phoneNumber nvarchar(MAX),
		@email nvarchar(MAX),
		@listType nvarchar(MAX),
		@category nvarchar(MAX),
		@location nvarchar(MAX),
		@landMark nvarchar(MAX),
		@features nvarchar(MAX),
		@amountRange nvarchar(MAX),
		@alertType nvarchar(MAX),
		@alertDuration nvarchar(MAX),
		@dateCreated datetime,
		@requestId nvarchar(MAX)
	
AS
BEGIN

	INSERT INTO [dbo].[RequestProperty] ([PropertyName],[PhoneNumber],[Email],[ListType],
	[Category],[Location],[LandMark],[Features],[AmountRange],[AlertType], [AlertDuration], [DateCreated], [RequestId])

	output inserted.Id

	VALUES(@propertyName,@phoneNumber,@email,@listType,@category,@location,
	@landMark,@features,@amountRange,@alertType,@alertDuration,@dateCreated,@requestId)
	                      
	END