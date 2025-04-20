public class CleanerSoftwareDistribution : Cleaner
{
    public CleanerSoftwareDistribution() : base("Software Distribution")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\SoftwareDistribution");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}