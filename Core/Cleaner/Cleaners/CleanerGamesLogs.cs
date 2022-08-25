public class CleanerGamesLogs : Cleaner
{
    public CleanerGamesLogs() : base("Games Logs", "Games")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(true);
    }

    public void CustomFindForFiles()
    {
        this.ClearFoundFiles();

        try
        {
            if (!Utils.IsFinding())
            {
                return;
            }

            foreach (string drive in Utils.GetDrives())
            {
                if (!Utils.IsFinding())
                {
                    return;
                }

                try
                {
                    if (System.IO.Directory.Exists(drive + @"\Program Files (x86)\Epic Games\Epic Online Services\service"))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(drive + @"\Program Files (x86)\Epic Games\Epic Online Services\service"))
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                try
                                {
                                    if (System.IO.Path.GetExtension(file).ToLower().Equals(".log"))
                                    {
                                        if (!Utils.IsFinding())
                                        {
                                            return;
                                        }

                                        try
                                        {
                                            this.AddFoundFile(file);
                                        }
                                        catch
                                        {

                                        }

                                        if (!Utils.IsFinding())
                                        {
                                            return;
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

        this.SetFindingCompleted(true);
    }

    public void CustomCleanFiles()
    {

    }
}