public class CleanerPackageCache : Cleaner
{
    public CleanerPackageCache() : base("Package Cache")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Package Cache");
            this.AddDirectory(drive + @"\ProgramData\Package Cache");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}