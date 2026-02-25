@echo off
set "SOURCE=Tool\bin\Release\net8.0-windows"
set "DEST_PARENT=\"
set "DEST_FOLDER=CDNT"
set "FULL_DEST=%DEST_PARENT%%DEST_FOLDER%"
set "ZIP_NAME=CDNT.zip"
set "ZIP_EXE=C:\Program Files\7-Zip\7z.exe"

echo --- Cleaning up old files ---
if exist "%FULL_DEST%" rd /s /q "%FULL_DEST%"
if exist "%ZIP_NAME%" del /f /q "%ZIP_NAME%"

echo --- Creating destination directory ---
mkdir "%FULL_DEST%"

echo --- Copying files ---
xcopy "%SOURCE%\*" "%FULL_DEST%\" /E /Y /I

echo --- Compressing with 7-Zip ---
if exist "%ZIP_EXE%" (
    :: We run the command from the parent directory so the zip contains the folder 'CDNT'
    pushd "%DEST_PARENT%"
    "%ZIP_EXE%" a -tzip "%~dp0%ZIP_NAME%" "%DEST_FOLDER%"
    popd
    
    echo Success! Created %ZIP_NAME% with subfolder /CDNT/
) else (
    echo ERROR: 7-Zip not found at %ZIP_EXE%
)

pause