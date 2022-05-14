CREATE PROCEDURE [dbo].[spUpdateTour]

	@id bigint,
		@phoneNumber nvarchar(MAX),
		@email nvarchar(MAX),
		@date nvarchar(MAX),
		@time nvarchar(MAX),
		@payment nvarchar(MAX),
		@fullName nvarchar(MAX),
		@tourId nvarchar(MAX)

AS
BEGIN
	UPDATE [dbo].[Tour] SET


		[PhoneNumber] = @phoneNumber,
		[Email] = @email,
		[Date] = @date,
		[Time] = @time,
		[Payment] = @payment,
		[FullName] = @fullName,
		[TourId] = @tourId

	WHERE [Id] = @id
END
