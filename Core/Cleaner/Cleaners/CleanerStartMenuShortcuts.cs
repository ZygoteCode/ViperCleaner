public class CleanerStartMenuShortcuts : Cleaner
{
    public CleanerStartMenuShortcuts() : base("Start Menu Shortcuts")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(false);
        this.SetCustomClean(true);
        this.SetCustomCleanSostitutive(false);

        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\appdata\roaming\microsoft\windows\start menu\programs");
            this.AddDirectory(drive + @"\programdata\microsoft\windows\start menu\programs");
        }
    }

    public void CustomFindForFiles()
    {
        this.ClearFoundFiles();
        this.SetFindingCompleted(true);
    }

    public void CustomCleanFiles()
    {
        Utils.RunPowerShell(@"Get-ChildItem ""$env:PROGRAMDATA\ Microsoft \ Windows \ Start Menu\Programs\*.lnk"" -recurse|ForEach-Object { Remove-Item $_ }");
        this.SetCleaningCompleted(true);
    }
}