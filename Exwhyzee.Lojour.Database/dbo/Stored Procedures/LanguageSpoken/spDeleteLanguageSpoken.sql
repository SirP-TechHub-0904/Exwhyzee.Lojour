--Delete an image

CREATE PROCEDURE [dbo].[spDeleteLangaugeSpoken]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[LanguageSpoken] Where [Id] = @Id
END