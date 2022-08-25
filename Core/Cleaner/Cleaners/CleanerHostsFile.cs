public class CleanerHostsFile : Cleaner
{
    public CleanerHostsFile() : base("Hosts File", "Network")
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
        try
        {
            foreach (string drive in Utils.GetDrives())
            {
                try
                {
                    if (System.IO.File.Exists(drive + @"\Windows\System32\drivers\etc\hosts"))
                    {
                        try
                        {
                            System.IO.File.WriteAllText(drive + @"\Windows\System32\drivers\etc\hosts", "127.0.0.1");
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }
        }
        catch
        {

        }

        this.SetCleaningCompleted(true);
    }
}