--Delete an image

CREATE PROCEDURE [dbo].[spDeletePropertyFeatures]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[PropertyFeature] Where [Id] = @Id
END