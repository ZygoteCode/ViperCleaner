public class CleanerCrashDumps : Cleaner
{
    public CleanerCrashDumps() : base("Crash Dumps")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\CrashDumps");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\CrashDumps");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\CrashDumps");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}