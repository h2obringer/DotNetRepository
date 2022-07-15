@ECHO OFF
REM ********************************************************************
REM Prerequisite: Run the build.bat in the parent folder first
REM 	This will ensure the ef tool is installed
REM ********************************************************************

cd ../../WorkByrdLibrary
ECHO *** ROLLING BACK LAST DATABASE SCHEMA MIGRATION
REM 
dotnet ef migrations remove --project "WorkByrdLibrary.csproj" --startup-project "../WorkByrdServer/WorkByrdServer.csproj" --verbose
cd ../DBA/EF

ECHO ****************************************************************************
ECHO *************** SCHEMA ROLLBACK COMPLETED SUCCESSFULLY *********************
ECHO ****************************************************************************
PAUSE