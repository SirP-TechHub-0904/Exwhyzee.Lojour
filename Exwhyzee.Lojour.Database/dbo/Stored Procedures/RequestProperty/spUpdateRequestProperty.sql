CREATE PROCEDURE [dbo].[spUpdateRequestProperty]

	@id bigint,
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
	UPDATE [dbo].[RequestProperty] SET

 	[PropertyName] = @propertyName,
		[PhoneNumber] = @phoneNumber,
		[Email] = @email,
		[ListType] = @listType,
		[Category] = @category,
		[Location] = @location,
		[LandMark] = @landMark,
		[Features] = @features,
		[AmountRange] = @amountRange,
		[AlertType] = @alertType,
		[AlertDuration] = @alertDuration,
		[DateCreated] = @dateCreated,
		[RequestId] = @requestId

	WHERE [Id] = @id
END
