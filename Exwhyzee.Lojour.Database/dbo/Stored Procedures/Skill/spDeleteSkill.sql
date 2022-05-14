--Delete an image

CREATE PROCEDURE [dbo].[spDeleteSkill]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[Skill] Where [Id] = @Id
END