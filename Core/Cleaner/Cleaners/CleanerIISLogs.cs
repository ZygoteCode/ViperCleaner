public class CleanerIISLogs : Cleaner
{
    public CleanerIISLogs() : base("IIS Logs", "Network")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\inetpub\logs");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}