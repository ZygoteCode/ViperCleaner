public class CleanerSystemTempFiles : Cleaner
{
    public CleanerSystemTempFiles() : base("System Temp Files")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\ProgramData\USOShared\Logs");
            this.AddDirectory(drive + @"\Windows\ServiceProfiles\LocalService\AppData\Local");
            this.AddDirectory(drive + @"\Windows\ServiceProfiles\LocalService\AppData\LocalLow");
            this.AddDirectory(drive + @"\Program Files\Common Files\Microsoft Shared\ClickToRun\");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Windows");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Temp");
            this.AddDirectory(drive + @"C:\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Windows\Burn\Burn");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}