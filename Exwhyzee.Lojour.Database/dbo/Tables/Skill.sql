﻿CREATE TABLE [dbo].[Skill]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(MAX) NULL,

    [UserProfileId] BIGINT NOT NULL, 
   
)
