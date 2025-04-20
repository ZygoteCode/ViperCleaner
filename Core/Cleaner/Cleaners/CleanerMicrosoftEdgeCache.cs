public class CleanerMicrosoftEdgeCache : Cleaner
{
    public CleanerMicrosoftEdgeCache() : base("Microsoft Edge Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Edge");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}