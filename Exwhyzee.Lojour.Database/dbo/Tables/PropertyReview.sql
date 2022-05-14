CREATE TABLE [dbo].[PropertyReview]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PropertyId] BIGINT NOT NULL, 
    [RatingId] BIGINT NOT NULL, 
    [UserId] NVARCHAR(450) NOT NULL,
	[DateCreated] datetime not null,
)
