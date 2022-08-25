public class CleanerReportArchive : Cleaner
{
    public CleanerReportArchive() : base("Report Archive")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\ProgramData\Microsoft\Windows\WER");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}