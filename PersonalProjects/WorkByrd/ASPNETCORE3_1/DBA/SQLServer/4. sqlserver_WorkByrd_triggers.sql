USE WorkByrd;

/*************************************************************************START AspNetUsersHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateAspNetUsersHistory'))
BEGIN
	DROP TRIGGER trg_CreateAspNetUsersHistory
END
GO
CREATE TRIGGER trg_CreateAspNetUsersHistory ON AspNetUsers 
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO AspNetUsersHistory(
		AspNetUsers_Id,		
		FirstName,
		LastName,
		Email,
		EmailConfirmed,
		PasswordHash,
		SecurityStamp,
		PhoneNumber,
		PhoneNumberConfirmed,
		TwoFactorEnabled,
		LockoutEndDateUtc,
		LockoutEnabled,
		AccessFailedCount,
		UserName,
		CreatedByUserID,
		dtCreatedUTC,
		LastModifiedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.Id, i.FirstName, i.LastName, i.Email, i.EmailConfirmed, i.PasswordHash, i.SecurityStamp, i.PhoneNumber, i.PhoneNumberConfirmed, 
	i.TwoFactorEnabled, i.LockoutEndDateUtc, i.LockoutEnabled, i.AccessFailedCount, i.UserName, i.CreatedByUserID, i.dtCreatedUTC, i.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.Id, d.FirstName, d.LastName, d.Email, d.EmailConfirmed, d.PasswordHash, d.SecurityStamp, d.PhoneNumber, d.PhoneNumberConfirmed, 
	d.TwoFactorEnabled, d.LockoutEndDateUtc, d.LockoutEnabled, d.AccessFailedCount, d.UserName, d.CreatedByUserID, d.dtCreatedUTC, d.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END AspNetUsersHistory*************************************************************************/

/*************************************************************************START AspNetRolesHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateAspNetRolesHistory'))
BEGIN
	DROP TRIGGER trg_CreateAspNetRolesHistory
END
GO
CREATE TRIGGER trg_CreateAspNetRolesHistory ON AspNetRoles
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO AspNetRolesHistory(
		AspNetRoles_Id,
		Name,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.Id, i.Name, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.Id, d.Name, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END AspNetRolesHistory*************************************************************************/

/*************************************************************************START AspNetUserRolesHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateAspNetUserRolesHistory'))
BEGIN
	DROP TRIGGER trg_CreateAspNetUserRolesHistory
END
GO
CREATE TRIGGER trg_CreateAspNetUserRolesHistory ON AspNetUserRoles
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO AspNetUserRolesHistory(
		AspNetUserRoles_UserId,
		AspNetUserRoles_RoleId,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.UserId, i.RoleId, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.UserId, d.RoleId, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END AspNetUserRolesHistory*************************************************************************/

/*************************************************************************START AspNetUserClaimsHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateAspNetUserClaimsHistory'))
BEGIN
	DROP TRIGGER trg_CreateAspNetUserClaimsHistory
END
GO
CREATE TRIGGER trg_CreateAspNetUserClaimsHistory ON AspNetUserClaims
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO AspNetUserClaimsHistory(
		AspNetUserClaims_Id,
		UserId,
		ClaimType,
		ClaimValue,
		CreatedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.Id, i.UserId, i.ClaimType, i.ClaimValue, i.CreatedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.Id, d.UserId, d.ClaimType, d.ClaimValue, d.CreatedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END AspNetUserClaimsHistory*************************************************************************/

/*************************************************************************START AspNetUserLoginsHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateAspNetUserLoginsHistory'))
BEGIN
	DROP TRIGGER trg_CreateAspNetUserLoginsHistory
END
GO
CREATE TRIGGER trg_CreateAspNetUserLoginsHistory ON AspNetUserLogins
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO AspNetUserLoginsHistory(
		LoginProvider,
		ProviderKey,
		UserId,
		CreatedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.LoginProvider, i.ProviderKey, i.UserId, i.CreatedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.LoginProvider, d.ProviderKey, d.UserId, d.CreatedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END AspNetUserLoginsHistory*************************************************************************/

/*************************************************************************START TimeZoneHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateTimeZoneHistory'))
BEGIN
	DROP TRIGGER trg_CreateTimeZoneHistory
END
GO
CREATE TRIGGER trg_CreateTimeZoneHistory ON TimeZone
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO TimeZoneHistory(
		TimeZone_ID,
		sAbbreviation,
		sName,
		sUTCOffset,
		bActive,
		ChangedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.ID, i.sAbbreviation, i.sName, i.sUTCOffset, i.bActive, i.ChangedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.ID, d.sAbbreviation, d.sName, d.sUTCOffset, d.bActive, d.ChangedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END TimeZoneHistory*************************************************************************/

/*************************************************************************START CountryHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateCountryHistory'))
BEGIN
	DROP TRIGGER trg_CreateCountryHistory
END
GO
CREATE TRIGGER trg_CreateCountryHistory ON Country
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO CountryHistory(
		Country_ID,
		sAbbreviation,
		sName,
		fkContinentID,
		bActive,
		ChangedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.ID, i.sAbbreviation, i.sName, i.fkContinentID, i.bActive, i.ChangedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.ID, d.sAbbreviation, d.sName, d.fkContinentID, d.bActive, d.ChangedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END CountryHistory*************************************************************************/

/*************************************************************************START CompanyHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateCompanyHistory'))
BEGIN
	DROP TRIGGER trg_CreateCompanyHistory
END
GO
CREATE TRIGGER trg_CreateCompanyHistory ON Company
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO CompanyHistory(
		Company_ID,
		sName,
		sPhone,
		sEmail,
		bEmailConfirmed,
		sAddressLine1,
		sAddressLine2,
		sAddressLine3,
		sCity,
		fkStateProvinceID,
		sZipCode,
		sURL,
		sBusinessHours,
		fkTimeZoneID,
		sSubscriptionType,
		dtSubscriptionExpirationUTC,
		CreatedByUserID,
		dtCreatedUTC,
		LastModifiedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.ID, i.sName, i.sPhone, i.sEmail, i.bEmailConfirmed, i.sAddressLine1, i.sAddressLine2, i.sAddressLine3, i.sCity, i.fkStateProvinceID, i.sZipCode, i.sURL, i.sBusinessHours, i.fkTimeZoneID, i.sSubscriptionType, i.dtSubscriptionExpirationUTC, i.CreatedByUserID, i.dtCreatedUTC, i.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.ID, d.sName, d.sPhone, d.sEmail, d.bEmailConfirmed, d.sAddressLine1, d.sAddressLine2, d.sAddressLine3, d.sCity, d.fkStateProvinceID, d.sZipCode, d.sURL, d.sBusinessHours, d.fkTimeZoneID, d.sSubscriptionType, d.dtSubscriptionExpirationUTC, d.CreatedByUserID, d.dtCreatedUTC, d.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END CompanyHistory*************************************************************************/

/*************************************************************************START CompanyEmployeeHistory*************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'trg_CreateCompanyEmployeeHistory'))
BEGIN
	DROP TRIGGER trg_CreateCompanyEmployeeHistory
END
GO
CREATE TRIGGER trg_CreateCompanyEmployeeHistory ON CompanyEmployee
AFTER INSERT, UPDATE, DELETE
NOT FOR REPLICATION
AS
	IF(ROWCOUNT_BIG() = 0) RETURN;
	SET NOCOUNT ON;
	--
    -- Check if this is an INSERT, UPDATE or DELETE Action.
    -- 
    DECLARE @Operation AS CHAR(1);

    SET @Operation = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
        SET @Operation = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
    ELSE
	BEGIN
        IF NOT EXISTS(SELECT * FROM INSERTED) 
		BEGIN
			RETURN; -- Nothing updated or inserted.
		END
	END
		
	INSERT INTO CompanyEmployeeHistory(
		CompanyEmployee_ID,
		fkCompanyID,
		fkAspNetUsersID,
		CreatedByUserID,
		dtCreatedUTC,
		LastModifiedByUserID,
		dtChangeDateUTC,
		sOperation
	)
	SELECT i.ID, i.fkCompanyID, i.fkAspNetUsersID, i.CreatedByUserID, i.dtCreatedUTC, i.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM inserted i
	UNION ALL
	SELECT d.ID, d.fkCompanyID, d.fkAspNetUsersID, d.CreatedByUserID, d.dtCreatedUTC, d.LastModifiedByUserID, GETUTCDATE(), @Operation
	FROM deleted d
	WHERE @Operation <> 'U';
GO
/*************************************************************************END CompanyEmployeeHistory*************************************************************************/