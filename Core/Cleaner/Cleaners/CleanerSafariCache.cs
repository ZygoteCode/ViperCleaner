public class CleanerSafariCache : Cleaner
{
    public CleanerSafariCache() : base("Safari Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        this.AddFile(Paths.SafariCache);
        this.AddDirectory(Paths.SafariHistory);
        this.AddFile(Paths.SafariHistoryDownloadsPlist);
        this.AddFile(Paths.SafariHistoryLastSessionPlist);
        this.AddFile(Paths.SafariHistoryPlist);
        this.AddDirectory(Paths.SafariWebpagePreviews);
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}