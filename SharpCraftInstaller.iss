; --- SharpCraft Installer Script ---
; Compiler MinGW style for C#
; Made by Sam M.

[Setup]
AppName=SharpCraft
AppVersion=1.4.1
AppPublisher=SharpCraft Team
AppPublisherURL=https://github.com/hecker-0101/SharpCraft
AppSupportURL=https://github.com/hecker-0101/SharpCraft/issues
AppUpdatesURL=https://github.com/hecker-0101/SharpCraft
DefaultDirName={pf}\SharpCraft
DefaultGroupName=SharpCraft
UninstallDisplayIcon={app}\SharpCraft.exe
OutputBaseFilename=SharpCraftInstaller
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
WizardImageFile=logo.bmp

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "C:\Users\USER\Desktop\SharpCraft\bin\Release\net9.0\win-x64\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SharpCraft"; Filename: "{app}\SharpCraft.exe"
Name: "{commondesktop}\SharpCraft"; Filename: "{app}\SharpCraft.exe"

[Registry]
Root: HKLM; Subkey: "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"; \
    ValueType: expandsz; ValueName: "Path"; ValueData: "{app};{olddata}"; Flags: preservestringtype

[Run]
Filename: "{app}\SharpCraft.exe"; Description: "Probar SharpCraft"; Flags: nowait postinstall skipifsilent