CREATE PROCEDURE [dbo].[spInsertProperty]

		@propertName nvarchar(MAX),
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

	INSERT INTO [dbo].[Property] ([PropertyName],[Description],[AgentDetails],[Longitude],
	[Latitude],[Amount],[PropertyProfile],[PropertyType],[PropertyStatus],[VerificationStatus], [DescriptiveStatus], [PropertyAddress],[DateCreated],
	[IdentificationNumber],[State],[LGA],[Community],[Kindred], [SortOrder], [HomeLocation], [Username], [Video], [PropertyLevel], [MapLink])

	output inserted.Id

	VALUES(@propertName,@description,@agentDetails,@longitude,@longitude,@amount,
	@propertyProfile,@propertyType,@propertyStatus,@verificationStatus,@descriptiveStatus,@propertyAddress,@dateCreated,@identificationNumber,
	@state,@lga,@community,@kindred,@sortOrder,@homeLocation,@username,@video,@propertyLevel,@mapLink)
	                      
	END