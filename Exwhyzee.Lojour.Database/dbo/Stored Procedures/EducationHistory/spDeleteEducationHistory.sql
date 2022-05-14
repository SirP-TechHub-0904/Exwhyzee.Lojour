--Delete an image

CREATE PROCEDURE [dbo].[spDeleteEducationHistory]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[EducationHistory] Where [Id] = @Id
END