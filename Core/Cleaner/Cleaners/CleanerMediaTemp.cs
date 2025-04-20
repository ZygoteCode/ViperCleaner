public class CleanerMediaTemp : Cleaner
{
    public CleanerMediaTemp() : base("Media Temp")
    {

    }

    public void Initialize()
    {
        this.AddDirectory(Paths.WindowsMediaPlayer);
        this.AddDirectory(Paths.QuickTimePlayerCache);
        this.AddDirectory(Paths.AdobeFlashPlayer);
        this.AddFile(Paths.QuickTimerPlayer);
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}