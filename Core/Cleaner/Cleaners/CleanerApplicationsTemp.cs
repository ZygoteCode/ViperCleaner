public class CleanerApplicationsTemp : Cleaner
{
    public CleanerApplicationsTemp() : base("Applications Temp", "Applications")
    {

    }

    public void Initialize()
    {
        this.AddDirectory(Paths.PaintNet);
        this.AddDirectory(Paths.uTorrentDllImageCache);
        this.AddDirectory(Paths.uTorrentTempFiles);
        this.AddDirectory(Paths.SunJavaCache);
        this.AddDirectory(Paths.SunJavaSystemCache);
        this.AddDirectory(Paths.FileZillaRecentServers);
        
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\UctTimer");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\lightcord");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Lightcord_BD");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Discord");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\BetterDiscord");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\CitizenFX");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\GlarySoft\Glary Utilities 5");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Construct2");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\FileZilla");
            this.AddFile(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Notepad++\session.xml");
            this.AddFile(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\Notepad++\config.xml");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\Documents\Rockstar Games\Launcher");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\Documents\Rockstar Games\Social Club");
            this.AddFile(drive + @"\program files\videolan\vlc\unistall.log");
            this.AddDirectory(drive + @"\ProgramData\Origin\Logs");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}