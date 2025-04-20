public class CleanerFontCache : Cleaner
{
    public CleanerFontCache() : base("Font Cache")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}