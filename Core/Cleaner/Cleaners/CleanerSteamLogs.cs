public class CleanerSteamLogs : Cleaner
{
    public CleanerSteamLogs() : base("Steam Logs", "Games")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Program Files (x86)\Steam\logs");
            this.AddDirectory(drive + @"\Program Files (x86)\Steam\dumps");
            this.AddDirectory(drive + @"\Program Files (x86)\Steam\userdata");
            this.AddDirectory(drive + @"\Program Files (x86)\Steam\config");

            this.AddDirectory(drive + @"\Steam\logs");
            this.AddDirectory(drive + @"\Steam\dumps");
            this.AddDirectory(drive + @"\Steam\userdata");
            this.AddDirectory(drive + @"\Steam\config");

            this.AddFile(drive + @"\Program Files (x86)\Steam\steamapps\common\Rust\RustClient_Data\output_log.txt");
            this.AddFile(drive + @"\Program Files (x86)\Steam\steamapps\common\Rust\RustClient_Data\output_log.last");

            this.AddFile(drive + @"\Steam\steamapps\common\Rust\RustClient_Data\output_log.txt");
            this.AddFile(drive + @"\Steam\steamapps\common\Rust\RustClient_Data\output_log.last");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}