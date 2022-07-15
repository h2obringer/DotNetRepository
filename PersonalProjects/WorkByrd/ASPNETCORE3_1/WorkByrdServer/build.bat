@ECHO OFF

REM Add the location for msbuild to the path variable just for this script
SET path=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin;%path%
REM Set the following variables to include/exclude the following steps
SET run_clean="N"
SET run_pkg_restore="N"
SET run_db_update="Y"
SET run_build="N"

REM  *** CLEAN ALL NUGET PACKAGES AND REFERENCE DLLS
IF %run_clean%=="Y" (
	ECHO *** CLEANING PACKAGE FILES
	dotnet nuget locals all --clear
	REM @rd /S /Q "packages"
	REM ECHO *** CLEANING DLL REFERENCES FOLDER
	REM @rd /S /Q "../references"
	
	ECHO ****************************************************************************
	ECHO ********************* CLEAN COMPLETED SUCCESSFULLY *************************
	ECHO ****************************************************************************
)

REM  *** RESTORE ALL NUGET PACKAGES FOR ALL SOLUTIONS
IF %run_pkg_restore%=="Y" (
	ECHO *** RESTORING NUGET PACKAGES
	dotnet restore "WorkByrdServer.csproj"
	REM nuget restore "../Server/WorkByrdServer.sln"
	REM nuget restore "AdminUserCreator/AdminCreator.sln"
	REM nuget restore "../WorkByrd.sln"
	ECHO ****************************************************************************
	ECHO ********************* RESTORE COMPLETED SUCCESSFULLY ***********************
	ECHO ****************************************************************************
)

IF %run_db_update%=="Y" (
	
	IF NOT EXIST ".config/dotnet-tools.json" (
		ECHO *** CREATING TOOL MANIFEST
		dotnet new tool-manifest
	)
	REM https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet
	ECHO *** INSTALLING EF Core 3.x .NET TOOL TO LOCAL TOOL PROJECT
	dotnet tool install dotnet-ef
	ECHO *** UPDATING DATABASE SCHEMA
	dotnet tool run dotnet-ef database update
)

REM  *** BUILD ALL SOLUTIONS WITHIN THE REPOSITORY
IF %run_build%=="Y" (
	REM OPTIONS:
	REM  /p:OutDir={path}
	REM  /p:referencepath={path}
	REM  /p:configuration=debug
	REM  /p:configuration=release
	REM  /t:Rebuild
	REM msbuild	"../Library/WorkByrdLibrary.sln" /t:Rebuild /p:configuration=debug
	REM xcopy "../Library/bin/Debug/WorkByrdLibrary.dll" "../References" /v /f /l /i /y
	REM IF NOT EXIST "../References" mkdir ../References
	REM robocopy "../Library/bin/Debug" "../References" WorkByrdLibrary.dll
	REM pause
	REM msbuild "../Server/WorkByrdServer.sln" /t:Rebuild /p:configuration=debug /p:referencepath=../References
	REM msbuild	"AdminUserCreator/AdminCreator.sln" /t:Rebuild /p:configuration=debug /p:referencepath=.../References
	REM msbuild "../WorkByrd.sln" /t:Rebuild /p:configuration=debug
	
	ECHO ****************************************************************************
	ECHO ********************* BUILD COMPLETED SUCCESSFULLY *************************
	ECHO ****************************************************************************
)


PAUSE