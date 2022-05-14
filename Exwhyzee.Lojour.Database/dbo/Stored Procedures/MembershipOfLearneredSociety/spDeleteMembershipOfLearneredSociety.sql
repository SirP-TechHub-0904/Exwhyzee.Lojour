--Delete an image

CREATE PROCEDURE [dbo].[spDeleteMembershipOfLearneredSociety]
	@Id bigInt = 0
AS
BEGIN
	Delete From [dbo].[MembershipOfLearneredSociety] Where [Id] = @Id
END