public class CleanerFirewall : Cleaner
{
    public CleanerFirewall() : base("Firewall", "Network")
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
        Utils.RunCommand("netsh advfirewall reset");
        this.SetCleaningCompleted(true);
    }
}