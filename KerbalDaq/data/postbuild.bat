set targetDir=%~1
set targetName=%~2
set targetExtension=%~3
set projectDir=%~4

set monoDir=C:\Program Files\Mono\bin
set kspDir=C:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program

cmd.exe /C ""%monoDir%\pdb2mdb.bat" "%targetDir%%targetName%%targetExtension%""

if not exist "%targetDir%\Plugins" (mkdir "%targetDir%\Plugins")

xcopy "%targetDir%%targetName%.*" "%targetDir%\Plugins" /Y
xcopy "%projectDir%data\ksp" "%kspDir%\GameData" /Y /S
