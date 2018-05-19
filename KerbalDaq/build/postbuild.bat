set targetDir=%~1
set targetName=%~2
set targetExtension=%~3
set projectDir=%~4
set solutionDir=%~5

set monoDir=C:\Program Files\Mono\bin
set kspDir=C:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program

cmd.exe /C ""%monoDir%\pdb2mdb.bat" "%targetDir%%targetName%%targetExtension%""

if not exist "%solutionDir%\Plugins" (mkdir "%targetDir%\Plugins")

xcopy "%targetDir%%targetName%.*" "%solutionDir%\Plugins" /Y
