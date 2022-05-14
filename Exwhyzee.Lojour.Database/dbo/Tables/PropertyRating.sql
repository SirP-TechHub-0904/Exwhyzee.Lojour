CREATE TABLE [dbo].[PropertyRating]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [RateOne] BIT NOT NULL,
    [RateTwo] BIT NOT NULL,
    [RateThree] BIT NOT NULL,
    [RateFour] BIT NOT NULL,
    [RateFive] BIT NOT NULL, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [Details] NVARCHAR(MAX) NULL, 
    [PropertyId] BIGINT NOT NULL,
	[DateCreated] datetime not null,
)
