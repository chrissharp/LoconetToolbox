; -- Setup.iss --
; Installer for Rocrail starter
;

#define AppId      "MgvLoconetToolbox_v1"
#define AppName    "LocoNet Toolbox"
#define AppShortName "LocoNet Toolbox"
#define AppExeName   "LocoNetToolbox"
#define AppVersion GetFileVersion("..\Build\Application\LocoNetToolbox.exe")

[Setup]
AppId={#AppId}
AppName={#AppName}
AppCopyright=Modelspoorgroep Venlo
AppVerName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
AppPublisher=MGV
AppPublisherURL=http://www.modelspoorgroepvenlo.nl
DefaultDirName={pf}\MGV\LocoNet
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
SetupIconFile=..\..\Source\WinApp\App.ico
WizardImageFile=..\..\Source\Graphics\Install\banner-164x314.bmp
WizardSmallImageFile=..\..\Source\Graphics\Install\banner-55x58.bmp
UninstallDisplayIcon={app}\{#AppExeName}.exe
Compression=lzma
SolidCompression=yes
OutputDir=..\Setup
OutputBaseFileName=LocoNetToolboxSetup
VersionInfoDescription={#AppName} installer
VersionInfoVersion={#AppVersion}
AllowUNCPath=no
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x86 x64
SourceDir=..\Build\Application

[Files]
Source: "LocoNetToolbox.exe"; DestDir: "{app}"; Flags: replacesameversion;

[Icons]
Name: "{group}\{#AppShortName}"; Filename: "{app}\LocoNetToolbox.exe"; WorkingDir: "{app}"

[Run]
Filename: "{app}\LocoNetToolbox.exe"; Description: "{cm:StartApp}"; Flags: postinstall nowait skipifsilent;

[UninstallDelete]
Type: filesandordirs; Name: "{app}";

[CustomMessages]
StartApp=Start {#AppName}
InstallDotNet=Install the Microsoft.NET 3.5 Framework first.

[Code]
const
  dotnet35URL = 'http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe';

function InitializeSetup(): Boolean;
var
  msgRes : integer;
  errCode : integer;

begin
  Result := true;
  // Check for required dotnetfx 3.5 installation
  if (not RegKeyExists(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5')) then begin
    msgRes := MsgBox(CustomMessage('InstallDotNet'), mbError, MB_OKCANCEL);
    if(msgRes = 1) then begin
      ShellExec('Open', dotnet35URL, '', '', SW_SHOW, ewNoWait, errCode);
    end;
    Abort();
  end;
end;


