public class CleanerDriverPackages : Cleaner
{
    public CleanerDriverPackages() : base("Driver Packages")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\System32\DriverStore\FileRepository");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}