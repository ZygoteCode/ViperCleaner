public class CleanerTCPIP : Cleaner
{
    public CleanerTCPIP() : base("TCP/IP", "Network")
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
        Utils.RunCommand("netsh int ip reset");
        Utils.RunCommand("netsh int ipv6 reset");
        this.SetCleaningCompleted(true);
    }
}