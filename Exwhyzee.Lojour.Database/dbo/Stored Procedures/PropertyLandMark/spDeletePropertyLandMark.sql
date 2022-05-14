--Delete an image

CREATE PROCEDURE [dbo].[spDeletePropertyLandMark]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[PropertyLandMark] Where [Id] = @Id
END