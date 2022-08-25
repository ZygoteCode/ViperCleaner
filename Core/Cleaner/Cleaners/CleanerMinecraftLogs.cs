public class CleanerMinecraftLogs : Cleaner
{
    public CleanerMinecraftLogs() : base("Minecraft Logs", "Games")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\.minecraft\logs");
            this.AddFile(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Roaming\.minecraft\launcher_log.txt");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}