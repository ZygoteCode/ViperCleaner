public class CleanerBITS : Cleaner
{
    public CleanerBITS() : base("BITS")
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
        Utils.RunCommand("bitsadmin /reset");
        this.SetCleaningCompleted(true);
    }
}