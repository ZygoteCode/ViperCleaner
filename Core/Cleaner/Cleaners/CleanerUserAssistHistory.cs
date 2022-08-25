public class CleanerUserAssistHistory : Cleaner
{
    public CleanerUserAssistHistory() : base("User Assist History")
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
        Utils.RunPowerShell("Delete-History -Windows");
        this.SetCleaningCompleted(true);
    }
}