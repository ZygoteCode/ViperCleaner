public class CleanerGoogleChromeCache : Cleaner
{
    public CleanerGoogleChromeCache() : base("Google Chrome Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Google\Software Reporter Tool");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Google\CrashReports");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Google\Chrome\User Data");
            this.AddDirectory(drive + @"\Program Files\Google\Chrome\Application\User_Data");

            if (System.IO.Directory.Exists(drive + @"\Program Files\Google\Chrome\Application"))
            {
                foreach (string folder in System.IO.Directory.GetDirectories(drive + @"\Program Files\Google\Chrome\Application"))
                {
                    if (folder.Contains("."))
                    {
                        this.AddDirectory(folder + "\\Installer");
                        break;
                    }
                }
            }
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}