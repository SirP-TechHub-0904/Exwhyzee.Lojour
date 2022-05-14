--Delete an image

CREATE PROCEDURE [dbo].[spDeleteJobAnalysis]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[JobAnalysis] Where [Id] = @Id
END