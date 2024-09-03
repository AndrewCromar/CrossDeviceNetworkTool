REM Define the source and target directories for the Tool
set "source_tool=D:\Programming\Winforms\CrossDeviceNetworkTool\Tool\bin\Debug\net8.0-windows"
set "target_tool=D:\Programming\Winforms\CrossDeviceNetworkTool\Build\Cross Device Network Tool\Tool"

REM Define the source and target directories for the Updater
set "source_updater=D:\Programming\Winforms\CrossDeviceNetworkTool\Updater\bin\Debug\net8.0-windows"
set "target_updater=D:\Programming\Winforms\CrossDeviceNetworkTool\Build\Cross Device Network Tool\Updater"

REM Define the source and target directories for the Dropbox copy
set "source_dropbox=D:\Programming\Winforms\CrossDeviceNetworkTool\Build\Cross Device Network Tool"
set "target_dropbox=C:\Users\andrew\Dropbox\Kids\Andrew\programming\c-sharp"

REM Copy files from the Tool directory
echo Copying files from %source_tool% to %target_tool%...
xcopy "%source_tool%\*" "%target_tool%\" /s /e /y

REM Copy files from the Updater directory
echo Copying files from %source_updater% to %target_updater%...
xcopy "%source_updater%\*" "%target_updater%\" /s /e /y

REM Copy the entire Cross Device Network Tool folder to Dropbox
echo Copying the entire Cross Device Network Tool folder to Dropbox...
xcopy "%source_dropbox%" "%target_dropbox%\Cross Device Network Tool" /s /e /y /i

REM Open the Tool folder in the Dropbox location
echo Opening the Tool folder in Dropbox...
start "" "%target_dropbox%\Cross Device Network Tool\Tool"

exit