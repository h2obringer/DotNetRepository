USE WorkByrd;

/*************************************************************************START USER ROLES*************************************************************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'SystemAdmin')
BEGIN
	INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) VALUES (CONVERT(VARCHAR(255), NEWID()), 'SystemAdmin', 'SYSTEMADMIN', CONVERT(VARCHAR(255), NEWID()))
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'CompanyAdmin')
BEGIN
	INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) VALUES (CONVERT(VARCHAR(255), NEWID()), 'CompanyAdmin', 'COMPANYADMIN', CONVERT(VARCHAR(255), NEWID()))
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'CompanyManager')
BEGIN
	INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) VALUES (CONVERT(VARCHAR(255), NEWID()), 'CompanyManager', 'COMPANYMANAGER', CONVERT(VARCHAR(255), NEWID()))
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'CompanySales')
BEGIN
	INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) VALUES (CONVERT(VARCHAR(255), NEWID()), 'CompanySales', 'COMPANYSALES', CONVERT(VARCHAR(255), NEWID()))
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM AspNetRoles WHERE Name = 'CompanyEmployee')
BEGIN
	INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) VALUES (CONVERT(VARCHAR(255), NEWID()), 'CompanyEmployee', 'COMPANYEMPLOYEE', CONVERT(VARCHAR(255), NEWID()))
END
GO
/*************************************************************************END USER ROLES*************************************************************************/

/*************************************************************************START TIME ZONES*************************************************************************/
 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ACDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ACDT', 'Australian Central Daylight Savings Time','+10:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ACST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ACST', 'Australian Central Standard Time','+09:30');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ACT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('ACT', 'Acre Time','-05', 1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ACWST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ACWST', 'Australian Central Western Standard Time','+08:45');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ADT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ADT', 'Atlantic Daylight Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AEDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AEDT', 'Australian Eastern Daylight Savings Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AEST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AEST', 'Australian Eastern Standard Time','+10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AFT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AFT', 'Afghanistan Time','+04:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AKDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AKDT', 'Alaska Daylight Time','-08');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AKST')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('AKST', 'Alaska Standard Time','-09',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ALMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ALMT', 'Alma-Ata Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AMST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AMST', 'Amazon Summer Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Amazon Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AMT', 'Amazon Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Armenia Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AMT', 'Armenia Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ANAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ANAT', 'Anadyr Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AQTT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AQTT', 'Aqtobe Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ART')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ART', 'Argentina Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Arabia Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AST', 'Arabia Standard Time','+03');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Atlantic Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('AST', 'Atlantic Standard Time','-04',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AWST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AWST', 'Australian Western Standard Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AZOST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AZOST', 'Azores Summer Time Time','+00');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AZOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AZOT', 'Azores Standard Time','-01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'AZT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('AZT', 'Azerbaijan Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BDT', 'Brunei Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BIOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BIOT', 'British Indian Ocean Time','+06');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BIT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('BIT', 'Baker Island Time','-12',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BOT', 'Bolivia Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BRST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BRST', 'Brasilia Summer Time','-02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BRT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BRT', 'Brasilia Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Bangladesh Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BST', 'Bangladesh Standard Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Bougainville Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BST', 'Bougainville Standard Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'British Summer Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BST', 'British Summer Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'BTT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('BTT', 'Bhutan Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CAT', 'Central Africa Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CCT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CCT', 'Cocos Islands Time','+06:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Central Daylight Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CDT', 'Central Daylight Time','-05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Cuba Daylight Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CDT', 'Cuba Daylight Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CEST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CEST', 'Central European Summer Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CET', 'Central European Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHADT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CHADT', 'Chatham Daylight Time','+13:45');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHAST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CHAST', 'Chatham Standard Time','+12:45');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CHOT', 'Choibalsan Summer Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHOST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CHOST', 'Choibalsan Summer Time','+09');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHST')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('CHST', 'Chamorro Standard Time','+10',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CHUT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CHUT', 'Chuuk Time','+10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CIST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CIST', 'Clipperton Island Standard Time','-08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CIT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CIT', 'Central Indonesia Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CKT', 'Cook Island Time','-10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CLST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CLST', 'Chile Summer Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CLT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CLT', 'Chile Standard Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'COST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('COST', 'Colombia Summer Time','-04');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'COT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('COT', 'Colombia Time','-05',1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Cental Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('CST', 'Cental Standard Time','-06',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'China Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CST', 'China Standard Time','+08');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Cuba Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('CST', 'Cuba Standard Time','-05',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CT', 'China Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CVT', 'Cape Verde Time','-01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CWST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CWST', 'Central Western Standard Time','+08:45');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'CXT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('CXT', 'Christmas Island Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'DAVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('DAVT', 'Davis Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'DDUT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('DDUT', 'Dumont d''Urville Time','+10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'DFT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('DFT', 'AIX-specific equivalent of Central European Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EASST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EASST', 'Easter Island Summer Time','-05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EAST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EAST', 'Easter Island Standard Time','-06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EAT', 'East Africa Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Eastern Caribbean Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ECT', 'Eastern Caribbean Time','-04');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Ecuador Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('ECT', 'Equador Time','-05',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EDT', 'Eastern Daylight Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EEST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EEST', 'Eastern European Summer Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EET', 'Eastern European Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EGST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EGST', 'Eastern Greenland Summer Time','+00');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EGT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EGT', 'Eastern Greenland Time','-01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EIT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('EIT', 'Eastern Indonesian Time','+09');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'EST')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('EST', 'Eastern Standard Time','-05',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'FET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('FET', 'Further-eastern European Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'FJT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('FJT', 'Fiji Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'FKST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('FKST', 'Falkland Islands Summer Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'FKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('FKT', 'Falkland Islands Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'FNT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('FNT', 'Fernando de Noronha Time','-02');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GALT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('GALT', 'Galapagos Time','-06',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GAMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GAMT', 'Gambier Islands Time','-09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GET', 'Georgia Standard Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GFT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GFT', 'French Guiana Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GILT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GILT', 'Gilbert Island Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GIT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GIT', 'Gambier Island Time','-09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GMT', 'Greenwich Mean Time','+00');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'South Georgia and the South Sandwish Islands Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GST', 'South Georgia and the South Sandwish Islands Time','-02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Gulf Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GST', 'Gulf Standard Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'GYT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('GYT', 'Guyana Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HDT', 'Hawaii-Aleutian Daylight Time','-09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HAEC')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HAEC', 'Heure Avancee d''Europe Centrale Time','+02');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HST')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('HST', 'Hawaii-Aleutian Standard Time','-10',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HKT', 'Hong Kong Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HMT', 'Heard and McDonald Islands Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HOVST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HOVST', 'Hovd Summer Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'HOVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('HOVT', 'Hovd Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ICT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ICT', 'Indochina Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IDLW')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IDLW', 'International Day Line West time zone Time','-12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IDT', 'Israel Daylight Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IOT', 'Indian Ocean Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IRDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IRDT', 'Iran Daylight Time','+04:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IRKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IRKT', 'Irkutsk Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'IRST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IRST', 'Iran Standard Time','+03:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Indian Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IST', 'Indian Standard Time','+05:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Irish Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IST', 'Irish Standard Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Israel Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('IST', 'Israel Standard Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'JST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('JST', 'Japan Standard Time','+09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'KALT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('KALT', 'Kaliningrad Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'KGT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('KGT', 'Kyrgyzstan Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'KOST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('KOST', 'Kosrae Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'KRAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('KRAT', 'Krasnoyarsk Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'KST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('KST', 'Korea Standard Time','+09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Lord Howe Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('LHST', 'Lord Howe Standard Time','+10:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Lord Howe Summer Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('LHST', 'Lord Howe Summer Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'LINT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('LINT', 'Line Islands Time','+14');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MAGT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MAGT', 'Magadan Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MART')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MART', 'Marquesas Islands Time','-09:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MAWT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MAWT', 'Mawson Station Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MDT', 'Mountain Daylight Time','-06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MET', 'Middle European Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MEST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MEST', 'Middle European Summer Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MHT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MHT', 'Marshall Islands Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MIST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MIST', 'Macquarie Island Station Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MIT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MIT', 'Marquesas Islands Time','-09:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MMT', 'Myanmar Standard Time','+06:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MSK')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MSK', 'Moscow Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Malaysia Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MST', 'Malaysia Standard Time','+08');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Mountain Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('MST', 'Mountain Standard Time','-07',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MUT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MUT', 'Mauritius Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MVT', 'Maldives Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'MYT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('MYT', 'Malaysia Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NCT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NCT', 'New Caledonia Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NDT', 'Newfoundland Daylight Time','-02:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NOVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NOVT', 'Novosibirsk Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NPT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NPT', 'Nepal Time','+05:45');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NST')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('NST', 'Newfoundland Standard Time','-03:30',1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('NT', 'Newfoundland Time','-03:30',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NUT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NUT', 'Niue Time','-11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NZDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NZDT', 'New Zealand Daylight Time','+13');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'NZST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('NZST', 'New Zealand Standard Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'OMST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('OMST', 'Omsk Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ORAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ORAT', 'Oral Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PDT', 'Pacific Daylight Time','-07');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PET')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('PET', 'Peru Time','-05',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PETT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PETT', 'Kamchatka Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PGT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PGT', 'Papua New Guinea Time','+10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PHOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PHOT', 'Pheonix Island Time','+13');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PHT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PHT', 'Philippine Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PKT', 'Pakistan Standard Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PMDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PMDT', 'Saint Pierre and Miquelon Daylight Time','-02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PMST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PMST', 'Saint Pierre and Miquelon Standard Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PONT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PONT', 'Pohnpei Standard Time','+11');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Pacific Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('PST', 'Pacific Standard Time','-08',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'PST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PST', 'Philippine Standard Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PYST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PYST', 'Paraguay Summer Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'PYT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('PYT', 'Paraguay Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'RET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('RET', 'Reunion Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ROTT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ROTT', 'Rothera Research Station Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SAKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SAKT', 'Sakhalin Island Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SAMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SAMT', 'Samara Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SAST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SAST', 'South African Standard Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SBT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SBT', 'Solomon Islands Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SCT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SCT', 'Seychelles Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SDT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SDT', 'Samoa Daylight Time','-10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SGT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SGT', 'Singapore Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SLST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SLST', 'Sri Lanka Standard Time','+05:30');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SRET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SRET', 'Srednekolymsk Time','+11');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SRT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SRT', 'Suriname Time','-03');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Samoa Standard Time')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('SST', 'Samoa Standard Time','-11',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sName = 'Singapore Standard Time')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SST', 'Singapore Standard Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'SYOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('SYOT', 'Showa Station Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TAHT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TAHT', 'Tahiti Time','-10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'THA')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('THA', 'Thailand Standard Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TFT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TFT', 'French Southern and Antarctic Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TJT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TJT', 'Tajikistan Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TKT', 'Tokelau Time','+13');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TLT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TLT', 'Timor Leste Time','+09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TMT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TMT', 'Turkmenistan Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TRT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TRT', 'Turkey Time','+03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TOT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TOT', 'Tonga Time','+13');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'TVT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('TVT', 'Tuvalu Time','+12');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ULAST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ULAST', 'Ulaanbaatar Summer Time','+09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'ULAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('ULAT', 'Ulaanbaatar Standard Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'UTC')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('UTC', 'Coordinated Universal Time','+00');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'UYST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('UYST', 'Uruguay Summer Time','-02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'UYT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('UYT', 'Uruguay Standard Time','-03');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'UZT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('UZT', 'Uzbekistan Time','+05');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'VET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('VET', 'Venezuelan Standard Time','-04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'VLAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('VLAT', 'Vladivostok Time','+10');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'VOLT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('VOLT', 'Volgograd Time','+04');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'VOST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('VOST', 'Vostok Station Time','+06');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'VUT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('VUT', 'Vanuatu Time','+11');
 END
 GO

IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WAKT')
BEGIN
	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset, bActive) VALUES ('WAKT', 'Wake Island Time','+12',1);
END
GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WAST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WAST', 'West Africa Summer Time','+02');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WAT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WAT', 'West Africa Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WEST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WEST', 'Western European Summer Time','+01');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WET')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WET', 'Western European Time','+00');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WIT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WIT', 'Western Indonesian Time','+07');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'WST')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('WST', 'Western Standard Time','+08');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'YAKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('YAKT', 'Yakutsk Time','+09');
 END
 GO

 IF NOT EXISTS(SELECT TOP 1 1 FROM TimeZone WHERE sAbbreviation = 'YEKT')
 BEGIN
 	INSERT INTO TimeZone(sAbbreviation, sName, sUTCOffset) VALUES ('YEKT', 'Yekaterinburg Time','+05');
 END
 GO
/*************************************************************************END TIME ZONES*************************************************************************/

/*************************************************************************START CONTINENTS*************************************************************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'North America')
BEGIN
	INSERT INTO Continent(sName) VALUES ('North America');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'South America')
BEGIN
	INSERT INTO Continent(sName) VALUES ('South America');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Europe')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Europe');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Africa')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Africa');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Asia')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Asia');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Australia')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Australia');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Antarctica')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Antarctica');
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Continent WHERE sName = 'Oceania')
BEGIN
	INSERT INTO Continent(sName) VALUES ('Oceania');
END
GO
/*************************************************************************END CONTINENTS*************************************************************************/

/*************************************************************************START COUNTRIES*************************************************************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'United States of America')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID, bActive) VALUES ('United States of America', 'US', (SELECT ID FROM Continent WHERE sName = 'North America'),1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mexico')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID, bActive) VALUES ('Mexico', 'MX', (SELECT ID FROM Continent WHERE sName = 'North America'),1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Canada')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID, bActive) VALUES ('Canada', 'CA', (SELECT ID FROM Continent WHERE sName = 'North America'),1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Afghanistan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Afghanistan', 'AF', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Albania')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Albania', 'AL', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Algeria')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Algeria', 'DZ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'American Somoa')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('American Somoa', 'AS', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Andorra')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Andorra', 'AD', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Angola')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Angola', 'AD', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Anguilla')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Anguilla', 'AD', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Antarctica')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Antarctica', 'AQ', (SELECT ID FROM Continent WHERE sName = 'Antarctica'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Antigua')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Antigua', 'AG', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Barbuda')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Barbuda', 'AG', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Argentina')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Argentina', 'AR', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Armenia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Armenia', 'AM', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Aruba')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Aruba', 'AW', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Australia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Australia', 'AU', (SELECT ID FROM Continent WHERE sName = 'Australia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Austria')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Austria', 'AT', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Azerbaijan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Azerbaijan', 'AZ', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bahamas')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bahamas', 'BS', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bahrain')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bahrain', 'BH', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bangladesh')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bangladesh', 'BD', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Barbados')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Barbados', 'BB', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Belarus')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Belarus', 'BY', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Belgium')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Belgium', 'BE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Belize')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Belize', 'BZ', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Benin')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Benin', 'BJ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bermuda')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bermuda', 'BM', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bhutan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bhutan', 'BT', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bhutan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bhutan', 'BT', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bolivia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bolivia', 'BO', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bosnia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bolivia', 'BA', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Herzegovina')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Herzegovina', 'BA', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Botswana')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Botswana', 'BW', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bouvet Island')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bouvet Island', 'BV', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Brazil')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Brazil', 'BR', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'British Indian Ocean Territory')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('British Indian Ocean Territory', 'IO', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Brunei Darussalam')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Brunei Darussalam', 'BN', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Bulgaria')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Bulgaria', 'BG', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Burkina Faso')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Burkina Faso', 'BF', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Burundi')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Burundi', 'BI', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cambodia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cambodia', 'KH', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cameroon')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cameroon', 'CM', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cape Verde')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cape Verde', 'CV', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cayman Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cayman Islands', 'KY', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Central African Republic')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Central African Republic', 'CF', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Chad')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Chad', 'TD', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Chile')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Chile', 'CL', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'People''s Republic of China')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('People''s Republic of China', 'CN', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Christmas Island')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Christmas Island', 'CX', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cocos Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cocos Islands', 'CC', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Colombia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Colombia', 'CO', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Comoros')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Comoros', 'KM', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Congo')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Congo', 'CG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'The Democratic Republic of Congo')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('The Democratic Republic of Congo', 'CD', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cook Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cook Islands', 'CK', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Costa Rica')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Costa Rica', 'CR', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'CÔTE D''IVOIRE')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('CÔTE D''IVOIRE', 'CI', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Croatia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Croatia', 'HR', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cuba')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cuba', 'CU', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Cyprus')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Cyprus', 'CY', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Czech Republic')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Czech Republic', 'CZ', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Denmark')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Denmark', 'DK', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Djibouti')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Djibouti', 'DJ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Dominica')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Dominica', 'DM', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Dominican Republic')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Dominican Republic', 'DO', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Equador')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Equador', 'EC', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Egypt')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Egypt', 'EG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Western Sahara')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Western Sahara', 'EH', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'El Salvador')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('El Salvador', 'ES', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Equatorial Guinea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Equatorial Guinea', 'GQ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Eritrea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Eritrea', 'ER', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Estonia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Estonia', 'EE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Ethiopia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Ethiopia', 'ET', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Falkland Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Falkland Islands', 'FK', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Faroe Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Faroe Islands', 'FO', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Fiji')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Fiji', 'FJ', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Finland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Finland', 'FI', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'France')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('France', 'FR', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'French Guiana')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('French Guiana', 'GF', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'French Polynesia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('French Polynesia', 'PF', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'French Southern Territories')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('French Southern Territories', 'TF', (SELECT ID FROM Continent WHERE sName = 'Antarctica'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Gabon')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Gabon', 'GA', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Gambia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Gambia', 'GM', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Georgia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Georgia', 'GE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Germany')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Germany', 'DE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Ghana')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Ghana', 'GH', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Gibraltar')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Gibraltar', 'GI', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Greece')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Greece', 'GR', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Greenland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Greenland', 'GL', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Grenada')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Grenada', 'GD', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guadeloupe')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guadeloupe', 'GP', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guam')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guam', 'GU', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guatemala')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guatemala', 'GT', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guinea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guinea', 'GN', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guinea-Bissau')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guinea-Bissau', 'GW', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Guyana')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Guyana', 'GY', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Haiti')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Haiti', 'HT', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Heard Island and McDonald Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Heard Island and McDonald Islands', 'HM', (SELECT ID FROM Continent WHERE sName = 'Antarctica'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Honduras')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Honduras', 'HN', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Hong Kong')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Hong Kong', 'HK', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Hungary')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Hungary', 'HU', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Iceland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Iceland', 'IS', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'India')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('India', 'IN', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Indonesia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Indonesia', 'ID', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Iran')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Iran', 'IR', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Iraq')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Iraq', 'IQ', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Ireland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Ireland', 'IE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Israel')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Israel', 'IL', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Italy')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Italy', 'IT', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Jamaica')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Jamaica', 'JM', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Japan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Japan', 'JP', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Jordan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Jordan', 'JO', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Kazakhstan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Kazakhstan', 'KZ', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Kenya')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Kenya', 'KE', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Kiribati')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Kiribati', 'KI', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'North Korea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('North Korea', 'KP', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'South Korea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('South Korea', 'KR', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Kuwait')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Kuwait', 'KW', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Kyrgyzstan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Kyrgyzstan', 'KG', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Lao')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Lao', 'LA', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Latvia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Latvia', 'LV', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Lebanon')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Lebanon', 'LB', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Lesotho')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Lesotho', 'LS', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Lesotho')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Lesotho', 'LS', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Liberia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Liberia', 'LR', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Libyan Arab Jamahiriya')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Libyan Arab Jamahiriya', 'LY', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Liechtenstein')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Liechtenstein', 'LI', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Lithuania')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Lithuania', 'LT', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Luxembourg')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Luxembourg', 'LU', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Macao')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Macao', 'MO', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Macedonia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Macedonia', 'MK', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Madagascar')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Madagascar', 'MG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Malawi')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Malawi', 'MW', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Malaysia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Malaysia', 'MY', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Maldives')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Maldives', 'MV', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mali')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Mali', 'ML', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Malta')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Malta', 'ML', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Marshall Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Marshall Islands', 'MH', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Martinique')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Martinique', 'MQ', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Maritania')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Maritania', 'MR', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mauritius')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Mauritius', 'MU', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mayotte')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Mayotte', 'YT', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Micronesia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Micronesia', 'FM', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Moldova')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Moldova', 'MD', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Monoco')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Monoco', 'MC', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mongolia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Mongolia', 'MN', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Montserrat')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Montserrat', 'MS', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Morocco')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Morocco', 'MA', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Mozambique')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Mozambique', 'MZ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Myanmar')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Myanmar', 'MM', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Namibia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Namibia', 'NA', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Nauru')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Nauru', 'NR', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Nepal')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Nepal', 'NP', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Netherlands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Netherlands', 'NL', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Netherlands Antilles')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Netherlands Antilles', 'AN', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'New Caledonia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('New Caledonia', 'NC', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'New Zealand')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('New Zealand', 'NZ', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Nicaragua')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Nicaragua', 'NI', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Niger')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Niger', 'NE', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Nigeria')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Nigeria', 'NG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Niue')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Niue', 'NU', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Northfolk Island')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Northfolk Island', 'NF', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Northern Mariana Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Northern Mariana Islands', 'MP', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Norway')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Norway', 'NO', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Oman')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Oman', 'OM', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Pakistan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Pakistan', 'PK', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Palau')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Palau', 'PK', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Palestine')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Palestine', 'PS', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Panama')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Panama', 'PA', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Papua New Guinea')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Papua New Guinea', 'PG', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Paraguay')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Paraguay', 'PY', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Peru')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Peru', 'PE', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Philippines')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Philippines', 'PH', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Pitcairn')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Pitcairn', 'PN', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Poland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Poland', 'PL', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Portugal')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Portugal', 'PT', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Puerto Rico')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Puerto Rico', 'PR', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Qatar')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Qatar', 'QA', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Reunion')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Reunion', 'RE', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Romania')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Romania', 'RO', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Russia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Russia', 'RU', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Rwanda')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Rwanda', 'RW', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saint Helena')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saint Helena', 'SH', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saint Kitts and Nevis')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saint Kitts and Nevis', 'KN', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saint Lucia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saint Lucia', 'LC', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saint Pierre and Miquelon')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saint Pierre and Miquelon', 'PM', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saint Vincent and the Grenadines')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saint Vincent and the Grenadines', 'VC', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Samoa')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Samoa', 'WS', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'San Marino')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('San Marino', 'SM', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Sao Tome and Principe')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Sao Tome and Principe', 'ST', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Saudi Arabia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Saudi Arabia', 'SA', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Senegal')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Senegal', 'SN', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Serbia and Montenegro')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Serbia and Montenegro', 'CS', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Seychelles')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Seychelles', 'SC', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Sierra Leone')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Sierra Leone', 'SL', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Singapore')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Singapore', 'SG', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Slovakia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Slovakia', 'SK', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Slovenia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Slovenia', 'SI', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Solomon Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Solomon Islands', 'SB', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Somolia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Somolia', 'SO', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'South Africa')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('South Africa', 'ZA', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'South Georgia and South Sandwich Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('South Georgia and South Sandwich Islands', 'GS', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Spain')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Spain', 'ES', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Sri Lanka')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Sri Lanka', 'LK', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Sudan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Sudan', 'SD', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Suriname')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Suriname', 'SR', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Svalbard and Jan Mayen')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Svalbard and Jan Mayen', 'SJ', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Swaziland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Swaziland', 'SZ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Sweden')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Sweden', 'SE', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Switzerland')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Switzerland', 'CH', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Syrian Arab Republic')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Syrian Arab Republic', 'SY', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Taiwan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Taiwan', 'TW', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tajikistan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tajikistan', 'TJ', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tanzania')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tanzania', 'TZ', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Thailand')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Thailand', 'TH', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Timor-Leste')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Timor-Leste', 'TL', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Togo')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Togo', 'TG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tokelau')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tokelau', 'TK', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tonga')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tonga', 'TO', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Trinidad and Tobago')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Trinidad and Tobago', 'TT', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tunisia')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tunisia', 'TN', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Turkey')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Turkey', 'TR', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Turkmenistan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Turkmenistan', 'TM', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Turks and Caicos Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Turks and Caicos Islands', 'TC', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Tuvalu')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Tuvalu', 'TV', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Uganda')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Uganda', 'UG', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Ukraine')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Ukraine', 'UA', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'United Arab Emirates')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('United Arab Emirates', 'AE', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'United Kingdom')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('United Kingdom', 'GB', (SELECT ID FROM Continent WHERE sName = 'Europe'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'United States Minor Outlying Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('United States Minor Outlying Islands', 'UM', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Uruguay')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Uruguay', 'UM', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Uzbekistan')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Uzbekistan', 'UZ', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Venezuela')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Venezuela', 'VE', (SELECT ID FROM Continent WHERE sName = 'South America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Vanuatu')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Vanuatu', 'VU', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Vietnam')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Vietnam', 'VN', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'British Virgin Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('British Virgin Islands', 'VG', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'U.S. Virgin Islands')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('U.S. Virgin Islands', 'VI', (SELECT ID FROM Continent WHERE sName = 'North America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Wallis and Futuna')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Wallis and Futuna', 'WF', (SELECT ID FROM Continent WHERE sName = 'Oceania'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Yemen')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Yemen', 'YE', (SELECT ID FROM Continent WHERE sName = 'Asia'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM Country WHERE sName = 'Zimbabwe')
BEGIN
	INSERT INTO Country(sName, sAbbreviation, fkContinentID) VALUES ('Zimbabwe', 'ZW', (SELECT ID FROM Continent WHERE sName = 'Africa'));
END
GO
/*************************************************************************END COUNTRIES*************************************************************************/

/*************************************************************************START STATE/PROVINCE*************************************************************************/
--U.S. states
IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Alabama' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Alabama', 'AL', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Alaska' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Alaska', 'AK', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Arizona' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Arizona', 'AZ', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Arkansas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Arkansas', 'AR', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'California' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('California', 'CA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Colorodo' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Colorodo', 'CO', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Connecticut' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Connecticut', 'CT', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Delaware' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Delaware', 'DE', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Florida' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Florida', 'FL', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Georgia' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Georgia', 'GA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Hawaii' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Hawaii', 'HI', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Idaho' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID, bHasTaxNexus) VALUES ('Idaho', 'ID', (SELECT ID FROM Country WHERE sName = 'United States of America'), 1);
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Illinois' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Illinois', 'IL', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Indiana' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Indiana', 'IN', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Iowa' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Iowa', 'IA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Kansas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Kansas', 'KS', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Kentucky' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Kentucky', 'KY', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Louisiana' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Louisiana', 'LA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Maine' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Maine', 'ME', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Maryland' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Maryland', 'MD', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Massachusetts' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Massachusetts', 'MA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Michigan' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Michigan', 'MI', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Minnesota' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Minnesota', 'MN', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Mississippi' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Mississippi', 'MS', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Missouri' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Missouri', 'MO', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Montana' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Montana', 'MT', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nebraska' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nebraska', 'NE', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nevada' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nevada', 'NV', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'New Hampshire' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('New Hampshire', 'NH', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'New Jersey' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('New Jersey', 'NJ', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'New Mexico' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('New Mexico', 'NM', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'New York' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('New York', 'NY', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'North Carolina' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('North Carolina', 'NC', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'North Dakota' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('North Dakota', 'ND', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Ohio' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Ohio', 'OH', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Oklahoma' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Oklahoma', 'OK', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Oregon' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Oregon', 'OR', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Pennsylvania' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Pennsylvania', 'PA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Rhode Island' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Rhode Island', 'RI', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'South Carolina' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('South Carolina', 'SC', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'South Dakota' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('South Dakota', 'SD', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Tennessee' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Tennessee', 'TN', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Texas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Texas', 'TX', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Utah' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Utah', 'UT', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Vermont' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Vermont', 'VT', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Virginia' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Virginia', 'VA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Washington' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Washington', 'WA', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'West Virginia' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('West Virginia', 'WV', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Wisconsin' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Wisconsin', 'WI', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Wyoming' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'United States of America'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Wyoming', 'WY', (SELECT ID FROM Country WHERE sName = 'United States of America'));
END
GO

--Canadian Provinces
IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Alberta' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Alberta', 'AB', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'British Columbia' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('British Columbia', 'BC', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Manitoba' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Manitoba', 'MB', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'New Brunswick' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('New Brunswick', 'NB', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Newfoundland and Labrador' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Newfoundland and Labrador', 'NL', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Northwest Territories' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Northwest Territories', 'NT', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nova Scotia' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nova Scotia', 'NS', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nunavut' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nunavut', 'NU', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Ontario' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Ontario', 'ON', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Prince Edward Island' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Prince Edward Island', 'PE', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Quebec' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Quebec', 'QC', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Saskatchewan' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Saskatchewan', 'SK', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Yukon' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Canada'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Yukon', 'YT', (SELECT ID FROM Country WHERE sName = 'Canada'));
END
GO

--Mexican states
IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Aguascalientes' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Aguascalientes', 'AG', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Baja California' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Baja California', 'BC', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Baja California Sur' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Baja California Sur', 'BS', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Campeche' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Campeche', 'CM', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Chiapas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Chiapas', 'CS', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Chihuahua' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Chihuahua', 'CH', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Coahuila' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Coahuila', 'CO', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Colima' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Colima', 'CL', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Mexico City' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Mexico City', 'DF', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Durango' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Durango', 'DG', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Guanajuato' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Guanajuato', 'GT', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Guerrero' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Guerrero', 'GR', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Hidalgo' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Hidalgo', 'HG', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Jalisco' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Jalisco', 'JA', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Mexico' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Mexico', 'EM', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Michoacan' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Michoacan', 'MI', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Morelos' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Morelos', 'MO', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nayarit' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nayarit', 'NA', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Nuevo Leon' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Nuevo Leon', 'NL', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Oaxaca' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Oaxaca', 'OA', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Puebla' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Puebla', 'PU', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Queretaro' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Queretaro', 'QT', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Quintana Roo' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Quintana Roo', 'QR', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'San Luis Potosi' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('San Luis Potosi', 'SL', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Sinaloa' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Sinaloa', 'SI', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Sonora' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Sonora', 'SO', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Tabasco' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Tabasco', 'TB', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Tamaulipas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Tamaulipas', 'TM', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Tlaxcala' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Tlaxcala', 'TL', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Veracruz' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Veracruz', 'VE', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Yucutan' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Yucutan', 'YU', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM StateProvince WHERE sName = 'Zacatecas' AND fkCountryID = (SELECT ID FROM Country WHERE sName = 'Mexico'))
BEGIN
	INSERT INTO StateProvince(sName, sAbbreviation, fkCountryID) VALUES ('Zacatecas', 'ZA', (SELECT ID FROM Country WHERE sName = 'Mexico'));
END
GO

/*************************************************************************END STATE/PROVINCE*************************************************************************/
