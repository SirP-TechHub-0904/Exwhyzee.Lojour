CREATE TABLE [dbo].[HelpfulReview]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PropertyReviewId] BIGINT NOT NULL, 
    [UserId] NVARCHAR(450) NOT NULL,
	[DateCreated] datetime not null,
)
