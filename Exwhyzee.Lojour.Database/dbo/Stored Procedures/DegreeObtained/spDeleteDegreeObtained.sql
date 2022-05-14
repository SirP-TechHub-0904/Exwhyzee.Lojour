--Delete an image

CREATE PROCEDURE [dbo].[spDeleteDegreeObtained]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[DegreeObtained] Where [Id] = @Id
END