; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "E4 Storage"
#define MyAppVersion "1.1"
#define MyAppPublisher "YH Dev"
#define MyAppCopyright "Copyright @ 2023 YH Dev"
#define MyAppURL "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppURLSupport "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppURLProduct "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppExeName "E4Storage.App.exe"
#define MyGroupApp "Inventory System"
#define MyYearApp "2024"
#define MyAppId "{0F97CC0E-54E0-4727-B55F-F04648221405}"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURLSupport}
AppUpdatesURL={#MyAppURLProduct}
AppCopyright={#MyAppCopyright}
CreateUninstallRegKey=True
DefaultDirName={commonpf}\{#MyGroupApp}\E4Storage
DefaultGroupName={#MyGroupApp}\E4Storage
OutputBaseFilename=E4Storage_SETUP
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallFilesDir={app}\uninst
SetupIconFile=inventory.ico
Compression=lzma
SolidCompression=yes
AllowRootDirectory=True
EnableDirDoesntExistWarning=True
InternalCompressLevel=ultra
PrivilegesRequired=admin
MinVersion=6.1.7601

[Languages]
Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl";

[Types]
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Tasks]
Name: "mssqllocaldbx86"; Description: "Install LocalDB 2019"; GroupDescription: "Harus diinstall:"; Flags: checkablealone; Check: Not IsWin64()
Name: "mssqllocaldbx64"; Description: "Install LocalDB 2019"; GroupDescription: "Harus diinstall:"; Flags: checkablealone; Check: IsWin64()
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone

[Files]
Source: "NDP461-KB3102436-x86-x64-AllOS-ENU.exe"; DestDir: {tmp}; Flags: deleteafterinstall; AfterInstall: InstallFramework; Check: FrameworkIsNotInstalled
Source: "..\E4Storage.App\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\E4Storage.App\bin\Debug\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
;Source: "..\E4Storage.App\bin\Debug\*.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\E4Storage.App\bin\Debug\*.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\E4Storage.App\bin\Debug\system\layouts\*"; DestDir: "{app}\System\Layouts"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "uninstall.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "addFirewall.txt"; DestDir: {app}; AfterInstall: OpenFirewall
;Source: "LocalDB_2019\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: ignoreversion; Tasks: mssqllocaldb; AfterInstall: RunOtherInstaller
Source: "LocalDB_2014\SqlLocalDB_x86.msi"; DestDir: "{tmp}"; Flags: ignoreversion; Tasks: mssqllocaldbx86; AfterInstall: RunOtherInstaller86
Source: "LocalDB_2014\SqlLocalDB_x64.msi"; DestDir: "{tmp}"; Flags: ignoreversion; Tasks: mssqllocaldbx64; AfterInstall: RunOtherInstaller64

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"; IconFilename: "{app}\{#MyAppExeName}"; IconIndex: 0; AfterInstall: SetElevationBit('{group}\{#MyAppName}.lnk')
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; IconFilename: "{app}\uninstall.ico"; IconIndex: 0

Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"; IconFilename: "{app}\{#MyAppExeName}"; IconIndex: 0; Tasks: desktopicon; AfterInstall: SetElevationBit('{commondesktop}\{#MyAppName}.lnk')

;[Run]
;Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Dirs]
Name: "{app}"; Permissions: everyone-full
Name: "{app}\System"; Permissions: everyone-full

[Registry]
Root: "HKLM"; Subkey: "Software\E4Storage"; ValueType: string; ValueName: "installDir"; ValueData: "{app}"; Flags: uninsdeletevalue

[Code]
var CancelWithoutPrompt: boolean;

procedure CancelButtonClick(CurPageID: Integer; var Cancel, Confirm: Boolean);
begin
  if CurPageID=wpInstalling then
    Confirm := not CancelWithoutPrompt;
end;

function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1'          .NET Framework 1.1
//    'v2.0'          .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//    'v4.5.1'        .NET Framework 4.5.1
//    'v4.5.2'        .NET Framework 4.5.2
//    'v4.6'          .NET Framework 4.6
//    'v4.6.1'        .NET Framework 4.6.1
//    'v4.6.2'        .NET Framework 4.6.2
//    'v4.7'          .NET Framework 4.7
//    'v4.7.1'        .NET Framework 4.7.1
//    'v4.7.2'        .NET Framework 4.7.2
//    'v4.8'          .NET Framework 4.8
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key, versionKey: string;
    install, release, serviceCount, versionRelease: cardinal;
    success: boolean;
begin
    versionKey := version;
    versionRelease := 0;

    // .NET 1.1 and 2.0 embed release number in version key
    if version = 'v1.1' then begin
        versionKey := 'v1.1.4322';
    end else if version = 'v2.0' then begin
        versionKey := 'v2.0.50727';
    end

    // .NET 4.5 and newer install as update to .NET 4.0 Full
    else if Pos('v4.', version) = 1 then begin
        versionKey := 'v4\Full';
        case version of
          'v4.5':   versionRelease := 378389;
          'v4.5.1': versionRelease := 378675; // 378758 on Windows 8 and older
          'v4.5.2': versionRelease := 379893;
          'v4.6':   versionRelease := 393295; // 393297 on Windows 8.1 and older
          'v4.6.1': versionRelease := 394254; // 394271 before Win10 November Update
          'v4.6.2': versionRelease := 394802; // 394806 before Win10 Anniversary Update
          'v4.7':   versionRelease := 460798; // 460805 before Win10 Creators Update
          'v4.7.1': versionRelease := 461308; // 461310 before Win10 Fall Creators Update
          'v4.7.2': versionRelease := 461808; // 461814 before Win10 April 2018 Update
          'v4.8':   versionRelease := 528040; // 528049 before Win10 May 2019 Update
        end;
    end;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + versionKey;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0 and newer use value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 and newer use additional value Release
    if versionRelease > 0 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= versionRelease);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;

function FrameworkIsNotInstalled: Boolean;
begin
  Result := not IsDotNetDetected('v4.6.1', 0);
end;

procedure InstallFramework;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing .NET framework...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
      if not Exec(ExpandConstant('{tmp}\NDP461-KB3102436-x86-x64-AllOS-ENU.exe'), '/q /norestart', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
      begin
        // you can interact with the user that the installation failed
        MsgBox('.NET installation failed with code: ' + IntToStr(ResultCode) + '.',
               mbError, MB_OK);
        CancelWithoutPrompt := true;
        WizardForm.Close;       
      end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure RunOtherInstaller86;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing LocalDB Database...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
      if not ShellExec('', ExpandConstant('{tmp}\SqlLocalDB_x86.msi'), 'IACCEPTSQLLOCALDBLICENSETERMS=YES /qn', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
      begin
        MsgBox('LocalDB 32 bit installer failed to run!' + #13#10 +
                SysErrorMessage(ResultCode), mbError, MB_OK);
        CancelWithoutPrompt := true;
        WizardForm.Close;
      end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure RunOtherInstaller64;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing LocalDB Database...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
      if not ShellExec('', ExpandConstant('{tmp}\SqlLocalDB_x64.msi'), 'IACCEPTSQLLOCALDBLICENSETERMS=YES /qn', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
      begin
        MsgBox('LocalDB 64 bit installer failed to run!' + #13#10 +
                SysErrorMessage(ResultCode), mbError, MB_OK);
        CancelWithoutPrompt := true;
        WizardForm.Close;
      end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure RunOtherInstaller;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing LocalDB Database...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
      if not ShellExec('', ExpandConstant('{tmp}\SqlLocalDB.msi'), 'IACCEPTSQLLOCALDBLICENSETERMS=YES /qn', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
      begin
        MsgBox('LocalDB installer failed to run!' + #13#10 +
                SysErrorMessage(ResultCode), mbError, MB_OK);
        CancelWithoutPrompt := true;
        WizardForm.Close;
      end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure SetElevationBit(Filename: string);
var
  Buffer: string;
  Stream: TStream;
begin
  Filename := ExpandConstant(Filename);
  Log('Setting elevation bit for ' + Filename);

  Stream := TFileStream.Create(FileName, fmOpenReadWrite);
  try
    Stream.Seek(21, soFromBeginning);
    SetLength(Buffer, 1);
    Stream.ReadBuffer(Buffer, 1);
    Buffer[1] := Chr(Ord(Buffer[1]) or $20);
    Stream.Seek(-1, soFromCurrent);
    Stream.WriteBuffer(Buffer, 1);
  finally
    Stream.Free;
  end;
end;

procedure OpenFirewall;
var
  StatusText: string;
  ResultCode: Integer;
  W7Command: String;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Configure Firewall ...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  
  try
    //Delete dulu
    W7Command := 'netsh advfirewall firewall delete rule name="YHDev" dir=in';
    Exec(ExpandConstant('{cmd}'), '/C ' + W7Command, '', SW_HIDE, ewWaitUntilTerminated, ResultCode)

    //Baru Add
    W7Command := 'netsh advfirewall firewall add rule name="YHDev" dir=in action=allow protocol=TCP localport="1433,443,445,80,8080,8081,21,139"';
    if not Exec(ExpandConstant('{cmd}'), '/C ' + W7Command, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
    begin
      MsgBox('Add Firewall Failed. Click OK to Continue and Add Exception Firewall manually.' + #13#10 +
              SysErrorMessage(ResultCode), mbError, MB_OK);
      WizardForm.Close;
    end;
  finally
    Log(SysErrorMessage(ResultCode));
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;