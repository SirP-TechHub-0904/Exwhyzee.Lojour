CREATE PROCEDURE [dbo].[spInsertTour]


		@phoneNumber nvarchar(MAX),
		@email nvarchar(MAX),
		@date nvarchar(MAX),
		@time nvarchar(MAX),
		@payment nvarchar(MAX),
		@fullName nvarchar(MAX),
		@tourId nvarchar(MAX)
		
	
AS
BEGIN

	INSERT INTO [dbo].[Tour] ([PhoneNumber],[Email],[Date],
	[Time],[Payment],[FullName],[TourId])

	output inserted.Id

	VALUES(@phoneNumber,@email,@date,@time,@payment,
	@fullName,@tourId)
	                      
	END