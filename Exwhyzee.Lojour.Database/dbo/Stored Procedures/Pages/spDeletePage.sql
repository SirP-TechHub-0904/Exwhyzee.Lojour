--Delete an image

CREATE PROCEDURE [dbo].[spDeletePage]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Page] Where [Id] = @Id
END