--Delete an image

CREATE PROCEDURE [dbo].[spDeleteWorkImage]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[WorkImage] Where [Id] = @Id
END