﻿-- Get an image by identifier

CREATE PROCEDURE [dbo].[spGetByIdMembershipOfLearneredSociety]
	@id bigint = 0

AS
BEGIN

	SELECT * From [dbo].[MembershipOfLearneredSociety] Where [Id] = @id

END
