-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdTrainingAndWorkShop]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[TrainingAndWorkShop] Where [Id] = @id

END
