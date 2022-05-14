--Delete an image

CREATE PROCEDURE [dbo].[spDeleteCommunity]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Community] Where [Id] = @Id
END