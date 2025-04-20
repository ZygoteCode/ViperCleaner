public class CleanerThumbnailCache : Cleaner
{
    public CleanerThumbnailCache() : base("Thumbnail Cache")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddFile(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\IconCache.db");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Windows\Explorer");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}