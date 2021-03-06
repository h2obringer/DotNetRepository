/*USE THIS SCRIPT WITH CAUTION*/
USE WorkByrd;

/*********************START DROP TABLES********************/

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StripePaymentMethodHistory')
BEGIN
    DROP TABLE StripePaymentMethodHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StripePaymentMethod')
BEGIN
    DROP TABLE StripePaymentMethod
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserAccessLog')
BEGIN
    DROP TABLE UserAccessLog
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompanyEmployee')
BEGIN
    DROP TABLE CompanyEmployee
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompanyEmployeeHistory')
BEGIN
    DROP TABLE CompanyEmployeeHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Company')
BEGIN
    DROP TABLE Company
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompanyHistory')
BEGIN
    DROP TABLE CompanyHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TimeZone')
BEGIN
    DROP TABLE TimeZone
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TimeZoneHistory')
BEGIN
    DROP TABLE TimeZoneHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StateProvince') 
BEGIN
    DROP TABLE StateProvince
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StateProvinceHistory') 
BEGIN
    DROP TABLE StateProvinceHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Country')
BEGIN
    DROP TABLE Country
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CountryHistory')
BEGIN
    DROP TABLE CountryHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Continent')
BEGIN
    DROP TABLE Continent
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserClaims')
BEGIN
    DROP TABLE AspnetUserClaims
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserClaimsHistory')
BEGIN
    DROP TABLE AspnetUserClaimsHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserLogins')
BEGIN
    DROP TABLE AspnetUserLogins
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserLoginsHistory')
BEGIN
    DROP TABLE AspnetUserLoginsHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserRoles')
BEGIN
    DROP TABLE AspnetUserRoles
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUserRolesHistory')
BEGIN
    DROP TABLE AspnetUserRolesHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserTokens')
BEGIN
	DROP TABLE AspNetUserTokens
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserTokensHistory')
BEGIN
	DROP TABLE AspNetUserTokensHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetRoleClaims')
BEGIN
	DROP TABLE AspNetRoleClaims
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetRoleClaimsHistory')
BEGIN
	DROP TABLE AspNetRoleClaimsHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUsers')
BEGIN
    DROP TABLE AspnetUsers
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetUsersHistory')
BEGIN
    DROP TABLE AspnetUsersHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetRoles')
BEGIN
    DROP TABLE AspnetRoles
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspnetRolesHistory')
BEGIN
    DROP TABLE AspnetRolesHistory
END
GO

IF EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'WorkByrdLog')
BEGIN
    DROP TABLE WorkByrdLog
END
GO
/*********************END DROP TABLES********************/

/*********************START DROP STORED PROCEDURES********************/
--IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE type = 'P' AND name = 'sp_MakeSystemAdmin')
--BEGIN
--	DROP PROCEDURE sp_MakeSystemAdmin
--END
--GO
/*********************END DROP STORED PROCEDURES********************/