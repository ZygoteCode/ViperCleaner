public class CleanerOperaCache : Cleaner
{
    public CleanerOperaCache() : base("Opera Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Opera Software");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Opera Software");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}