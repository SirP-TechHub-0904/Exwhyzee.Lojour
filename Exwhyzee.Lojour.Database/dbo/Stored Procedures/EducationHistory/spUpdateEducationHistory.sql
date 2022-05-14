CREATE PROCEDURE [dbo].[spUpdateEducationHistory]

	@id bigint,
	@schoolAttended nvarchar(MAX),
	@course nvarchar(MAX),
	@startDate nvarchar(MAX),
	@endDate nvarchar(MAX),
	@grade nvarchar(MAX),
	@isCurrent bit,
	@userProfileId bigint
AS
BEGIN
	UPDATE [dbo].[EducationHistory] SET

	[SchoolAttended] = @schoolAttended,
	[Course] = @course,
	[StartDate] = @startDate,
	[EndDate] = @endDate,
	[Grade] = grade,
	[IsCurrent] = @isCurrent,
	[UserProfileId] = @userProfileId
	
	

	WHERE [Id] = @id
END
