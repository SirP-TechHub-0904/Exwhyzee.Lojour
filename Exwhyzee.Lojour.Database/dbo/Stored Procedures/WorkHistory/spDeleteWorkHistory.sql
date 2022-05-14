--Delete an image

CREATE PROCEDURE [dbo].[spDeleteWorkHistory]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[WorkHistory] Where [Id] = @Id
END