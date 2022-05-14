--Delete an image

CREATE PROCEDURE [dbo].[spDeleteRenderedService]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[RenderedService] Where [Id] = @Id
END