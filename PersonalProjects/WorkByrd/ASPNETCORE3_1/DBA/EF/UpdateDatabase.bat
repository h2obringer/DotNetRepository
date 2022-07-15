@ECHO OFF
REM ********************************************************************
REM Prerequisite: Run the build.bat in the parent folder first
REM 	This will ensure the ef tool is installed
REM ********************************************************************

cd ../../WorkByrdLibrary
ECHO *** UPDATING DATABASE SCHEMA FROM FILES
REM 
dotnet ef database update --project "WorkByrdLibrary.csproj" --startup-project "../WorkByrdServer/WorkByrdServer.csproj" --verbose
cd ../DBA/EF

ECHO ****************************************************************************
ECHO *************** SCHEMA (MIGRATION) UPGRADED SUCCESSFULLY *******************
ECHO ****************************************************************************
PAUSE