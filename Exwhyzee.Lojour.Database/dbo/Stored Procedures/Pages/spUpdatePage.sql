CREATE PROCEDURE [dbo].[spUpdatePage]

	@id bigint,
@title nvarchar(MAX),
	@pageStatus int,
	@content nvarchar(MAX),
	@pagePosition int
AS
BEGIN
	UPDATE [dbo].[Page] SET

	[Title] = @title,
	[PageStatus] = @pageStatus,
	[Content] = @content,
	[PagePosition] = @pagePosition

	WHERE [Id] = @id
END
