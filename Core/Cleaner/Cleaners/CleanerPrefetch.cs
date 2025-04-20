public class CleanerPrefetch : Cleaner
{
    public CleanerPrefetch() : base("Prefetch")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\Prefetch");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}