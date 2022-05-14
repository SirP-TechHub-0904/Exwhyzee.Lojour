--Delete an image

CREATE PROCEDURE [dbo].[spDeleteKindred]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Kindred] Where [Id] = @Id
END