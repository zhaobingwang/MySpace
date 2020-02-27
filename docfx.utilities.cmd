set docfxPath=..\..\tools\docfx\docfx.exe

mkdir .docfx\MySpace.Utilities
cd .docfx\MySpace.Utilities

%docfxPath% init -q
%docfxPath% .\docfx_project\docfx.json

%docfxPath% metadata ..\..\src\MySpace.Utilities\MySpace.Utilities.csproj

xcopy /d /y "_api\*" "docfx_project\api\"

%docfxPath% .\docfx_project\docfx.json
%docfxPath% serve .\docfx_project\_site\
pause