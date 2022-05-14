--Delete an image

CREATE PROCEDURE [dbo].[spDeleteLGA]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[LGA] Where [Id] = @Id
END