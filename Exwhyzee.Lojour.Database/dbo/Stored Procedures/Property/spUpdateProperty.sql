CREATE PROCEDURE [dbo].[spUpdateProperty]

	@id bigint,
@propertyName nvarchar(MAX),
		@description nvarchar(MAX),
		@agentDetails nvarchar(MAX),
		@longitude nvarchar(MAX),
		@latitude nvarchar(MAX),
		@amount decimal(18,2),
		@propertyProfile nvarchar(MAX),
	@propertyType nvarchar(MAX),
		@propertyStatus int,
		@verificationStatus int,
		@descriptiveStatus int,
		@propertyAddress nvarchar(MAX),
	@dateCreated datetime,
	@identificationNumber nvarchar(MAX),
	@state nvarchar(450),
	@lga nvarchar(450),
	@community nvarchar(450),
	@kindred nvarchar(450),
	@sortOrder int,
	@homeLocation int,
	@username nvarchar(50),
		@video nvarchar(MAX),
			@propertyLevel nvarchar(MAX),
				@mapLink nvarchar(MAX)



AS
BEGIN
	UPDATE [dbo].[Property] SET

	[PropertyName] = @propertyName,
	[Description] = @description,
	[AgentDetails] = @agentDetails,
	[Longitude] = @longitude,
	[Latitude] = @latitude,
	[Amount] = @amount,
	[PropertyProfile] = @propertyProfile,
	[PropertyType] = @propertyType,
	[PropertyStatus] = @propertyStatus,
	[VerificationStatus] = @verificationStatus,
	[DescriptiveStatus] = @descriptiveStatus,
	[PropertyAddress] = @propertyAddress,
	[DateCreated] = @dateCreated,
	[IdentificationNumber] = @identificationNumber,
	[State] = @state,
	[LGA] = @lga,
	[Community] = @community,
	[Kindred] = @kindred,
	[SortOrder] = @sortOrder,
	[HomeLocation] = @homeLocation,
	[Username] = @username,
	[Video] = @video,
	[PropertyLevel] = @propertyLevel,
	[MapLink] = @mapLink

	WHERE [Id] = @id
END
