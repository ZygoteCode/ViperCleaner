public class CleanerWindowsEventLogs : Cleaner
{
    public CleanerWindowsEventLogs() : base("Windows Event Logs")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(true);
        this.SetCustomClean(true);
        this.SetCustomCleanSostitutive(true);
    }

    public void CustomFindForFiles()
    {
        this.ClearFoundFiles();
        this.SetFindingCompleted(true);
    }

    public void CustomCleanFiles()
    {
        Utils.RunPowerShell("Get-EventLog -LogName * | ForEach { Clear - EventLog $_.Log }");
        Utils.RunPowerShell("wevtutil el | Foreach-Object {wevtutil cl “\"$_\"”}");
        this.SetCleaningCompleted(true);
    }
}