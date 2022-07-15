@ECHO OFF
REM ****************************************************************************
REM Prerequisite: Run the build.bat in the parent folder first
REM 	This will ensure the ef tool is installed
REM ****************************************************************************

SET migration_name=SCHEMA


REM ****************************************************************************
cd ../../WorkByrdLibrary
ECHO *** CREATING SCHEMA INSTALL FILES
REM 
dotnet ef migrations add %migration_name% --project "WorkByrdLibrary.csproj" --startup-project "../WorkByrdServer/WorkByrdServer.csproj" --verbose --output-dir "Data/Migrations"
cd ../DBA/EF

ECHO ****************************************************************************
ECHO *************** SCHEMA (MIGRATION) CREATED SUCCESSFULLY ********************
ECHO ****************************************************************************
PAUSE