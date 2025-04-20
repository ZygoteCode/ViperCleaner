public class CleanerAntivirusTemp : Cleaner
{
    public CleanerAntivirusTemp() : base("Antivirus Temp", "Applications")
    {

    }

    public void Initialize()
    {
        this.AddDirectory(Paths.AvgAntivirus10Backup);
        this.AddDirectory(Paths.AvgAntivirus10Log);
        this.AddDirectory(Paths.AvgAntivirus10Misc);
        this.AddDirectory(Paths.AvgAntivirus10Temps);
        this.AddDirectory(Paths.MalwareBytesLogs);
        this.AddDirectory(Paths.MalwareBytesQuarantineBackup);
        this.AddDirectory(Paths.WindowsDefenderHistoryQuick);
        this.AddDirectory(Paths.WindowsDefenderHistoryResource);
        this.AddDirectory(Paths.SpybotSdBackups);
        this.AddDirectory(Paths.SpybotSdIni);
        this.AddDirectory(Paths.SpybotSdLogs);
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}