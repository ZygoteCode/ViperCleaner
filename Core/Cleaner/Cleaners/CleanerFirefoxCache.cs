public class CleanerFirefoxCache : Cleaner
{
    public CleanerFirefoxCache() : base("Firefox Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Mozilla");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Mozilla\Firefox");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}