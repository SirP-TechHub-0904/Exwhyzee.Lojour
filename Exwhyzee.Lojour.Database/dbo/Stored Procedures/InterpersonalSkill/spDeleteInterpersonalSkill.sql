--Delete an image

CREATE PROCEDURE [dbo].[spDeleteInterpersonalSkill]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[InterpersonalSkill] Where [Id] = @Id
END