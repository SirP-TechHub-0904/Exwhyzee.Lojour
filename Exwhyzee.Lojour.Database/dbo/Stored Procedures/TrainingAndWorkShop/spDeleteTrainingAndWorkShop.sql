--Delete an image

CREATE PROCEDURE [dbo].[spDeleteTrainingAndWorkShop]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[TrainingAndWorkShop] Where [Id] = @Id
END