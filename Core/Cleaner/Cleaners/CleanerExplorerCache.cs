public class CleanerExplorerCache : Cleaner
{
    public CleanerExplorerCache() : base("Explorer Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        this.AddDirectory(Paths.WindowsExplorerRecent);
        this.AddDirectory(Paths.WindowsExplorerThumbnailCache);

        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Microsoft\Windows\Recent");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}