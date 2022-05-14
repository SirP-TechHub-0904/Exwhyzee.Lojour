--Delete an image

CREATE PROCEDURE [dbo].[spDeleteReferee]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Referee] Where [Id] = @Id
END