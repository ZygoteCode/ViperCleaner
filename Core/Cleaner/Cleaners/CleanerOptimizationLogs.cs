public class CleanerOptimizationLogs : Cleaner
{
    public CleanerOptimizationLogs() : base("Optimization Logs")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\windows\serviceprofiles\networkservice\appdata\local\microsoft\windows\DeliveryOptimization\Logs");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}