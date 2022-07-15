REM Create the ASP Session State Database
@ECHO ON

SET REGSQLPATH=C:\Windows\Microsoft.NET\Framework64\v2.0.50727
REM to be changed for production environment
SET SQLINSTANCE=ROBRINGER-PC\SQL2K14

REM ensure we are on the C:/ drive
C:

REM aspnet_regsql must be executed from this path...
cd %REGSQLPATH%

REM -E : Use Integrated Security when connecting to the SQL Server (login with the currently logged in Windows User)
REM -ssadd : Add support for the SQLServer mode session state
REM -sstype p : set the resulting database to use persistent storage (Stores session data in the ASPState database)
REM -d {database name} : Not used, therefore the database that will be created will be called ASPState

aspnet_regsql -S %SQLINSTANCE% -E -ssadd -sstype p

ECHO ***** SCRIPT FINISHED SUCCESSFULLY *****
PAUSE