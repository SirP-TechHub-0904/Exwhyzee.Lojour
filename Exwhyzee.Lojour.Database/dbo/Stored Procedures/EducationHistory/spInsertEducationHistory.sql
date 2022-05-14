-- Create a new image entity

CREATE PROCEDURE [dbo].[spInsertEducationHistory]
	@schoolAttended nvarchar(MAX),
	@course nvarchar(MAX),
	@startDate nvarchar(MAX),
	@endDate nvarchar(MAX),
	@grade nvarchar(MAX),
	@isCurrent bit,
	@userProfileId bigint
AS
BEGIN

	INSERT INTO [dbo].[EducationHistory] ([SchoolAttended], [Course], [StartDate], [EndDate],[Grade], [IsCurrent], [UserProfileId])

	output inserted.Id

	VALUES(@schoolAttended,@course,@startDate,@endDate,@grade,@isCurrent,@userProfileId )
	                      
	END
