--Delete an image

CREATE PROCEDURE [dbo].[spDeleteExperience]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Experience] Where [Id] = @Id
END