--USE WorkByrd;

--/*MAKE A USER NAME AN ADMINISTRATOR BY */
--IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE type = 'P' AND name = 'sp_MakeSystemAdmin')
--BEGIN
--	DROP PROCEDURE sp_MakeSystemAdmin
--END
--GO

--CREATE PROCEDURE sp_MakeSystemAdmin (
--	@UserEmailAddress VARCHAR(255)
--)
--AS
--BEGIN
--	SET NOCOUNT ON
	
--	IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'SystemAdmin')
--	BEGIN
--		RAISERROR('The SystemAdmin Role has not yet been created...', 1,1);
--	END

--	--CREATE THE USER IF IT DOESN'T ALREADY EXIST...
--	IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetUsers WHERE Email = @UserEmailAddress)
--	BEGIN
--		--INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, 
--		--TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, CreatedByUserID)
--		--VALUES(
--		--	CONVERT(VARCHAR(255), NEWID()),
--		--	@UserEmailAddress,
--		--	1,
--		--	'', --what do we do about this????
--		--	CONVERT(VARCHAR(255), NEWID()),
--		--	'',
--		--	0,
--		--	0,
--		--	NULL,
--		--	1,
--		--	0,
--		--	@UserEmailAddress,
--		--	''		
--		--)

--		RAISERROR('The SystemAdmin Role has not yet been created...', 1,1);
--	END
	
--	--CREATE THE COMPANY IF IT DOESN'T ALREADY EXIST...
--	IF NOT EXISTS(SELECT TOP 1 1 FROM Company WHERE sName = 'WorkByrd')
--	BEGIN

--		DECLARE @StateID AS NUMERIC(18,0), @TimeZoneID AS NUMERIC(18,0), @UserID AS NVARCHAR(128), @CompanyID AS NUMERIC(18,0)
--		SELECT @StateID = sp.ID FROM StateProvince sp WHERE sp.sName = 'Idaho' AND sp.fkCountryID = (SELECT TOP 1 c.ID FROM Country c WHERE c.sName = 'United States of America')
--		SELECT @TimeZoneID = t.ID FROM TimeZone t WHERE t.sName = 'Mountain Standard Time'
--		SELECT @UserID = u.Id FROM AspNetUsers u WHERE u.Email = @UserEmailAddress

--		INSERT INTO Company(sName, sPhone, sEmail, sAddressLine1, sAddressLine2, sAddressLine3, sCity, fkStateProvinceID,
--		sZipCode, sURL, sBusinessHours, dtCreatedUTC, fkTimeZoneID, fkCreatedByUserID, sSubscriptionType, dtSubscriptionExpirationUTC)
--		VALUES (
--			'WorkByrd', 
--			'11111111111',
--			'randy.obringer@gmail.com',
--			'',
--			'',
--			'',
--			'Boise',
--			@StateID,
--			'11111',
--			'localhost',
--			'Monday 9AM-5PM~Tuesday 9AM-5PM~Wednesday 9AM-5PM~Thursday 9AM-5PM~Friday 9AM-5PM',
--			GETUTCDATE(),
--			@TimeZoneID,
--			@UserID,
--			'MasterCraftsman',
--			DATEADD(year, 2000, GETUTCDATE()) --the subscription will end in 9000 years...
--		);
--	END

--	--ADD THE USER TO THE ROLE
--	INSERT INTO AspNetUserRoles (UserId, RoleId)
--	SELECT u.id, (SELECT r.Id FROM AspNetRoles r WHERE r.Name = 'SystemAdmin')
--	FROM AspNetUsers u
--	WHERE u.email = @UserEmailAddress

--	SELECT @CompanyID = c.ID FROM Company c WHERE c.sName = 'WorkByrd'

--	IF NOT EXISTS(SELECT TOP 1 1 FROM CompanyEmployee e WHERE e.fkAspNetUsersID = @UserID AND e.fkCompanyID = @CompanyID)
--	BEGIN
--		INSERT INTO CompanyEmployee (fkCompanyID, fkAspNetUsersID, dtCreatedUTC, fkCreatedByUserID)
--		VALUES (@CompanyID, @UserID, GETUTCDATE(), '')
--	END
--END
--GO