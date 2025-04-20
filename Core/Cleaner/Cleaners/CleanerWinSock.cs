public class CleanerWinSock : Cleaner
{
    public CleanerWinSock() : base("WinSock", "Network")
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
        Utils.RunCommand("netsh winsock reset");
        this.SetCleaningCompleted(true);
    }
}