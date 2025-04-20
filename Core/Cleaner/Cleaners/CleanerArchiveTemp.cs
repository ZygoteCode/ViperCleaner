public class CleanerArchiveTemp : Cleaner
{
    public CleanerArchiveTemp() : base("Archive Temp")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Temp");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Temp");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}