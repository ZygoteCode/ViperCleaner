public class CleanerKernelReports : Cleaner
{
    public CleanerKernelReports() : base("Kernel Reports")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\LiveKernelReports");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}