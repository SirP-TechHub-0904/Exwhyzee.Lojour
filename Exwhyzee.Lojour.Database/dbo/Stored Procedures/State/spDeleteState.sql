--Delete an image

CREATE PROCEDURE [dbo].[spDeleteState]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[State] Where [Id] = @Id
END