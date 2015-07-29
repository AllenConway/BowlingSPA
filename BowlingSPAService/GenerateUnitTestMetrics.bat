REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0BowlingSPAService.trx" del "%~dp0BowlingSPAService.trx%"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 ( 
	call :RunReportGeneratorOutput	
)
REM exit /b

REM Launch the report
if %errorlevel% equ 0 ( 
	call :RunLaunchReport	
)
REM exit /b


:RunOpenCoverUnitTestMetrics
"%~dp0..\packages\OpenCover.4.5.3723\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS120COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\BowlingSPAService.Tests\bin\Debug\BowlingSPAService.Tests.dll\" /resultsfile:\"%~dp0CallCenterProject.trx\"" ^
-filter:"+[BowlingSPAService*]* -[BowlingSPAService.Tests]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml"

:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.2.1.4.0\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"

:RunLaunchReport
CALL "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
EXIT
