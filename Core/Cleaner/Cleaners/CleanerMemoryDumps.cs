public class CleanerMemoryDumps : Cleaner
{
    public CleanerMemoryDumps() : base("Memory Dumps")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(false);

        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\MiniDump");
        }
    }

    public void CustomFindForFiles()
    {
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
                    if (System.IO.Directory.Exists(drive + @"\Windows"))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(drive + @"\Windows"))
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                try
                                {
                                    if (System.IO.Path.GetExtension(file).ToLower().Equals(".dmp"))
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
    }

    public void CustomCleanFiles()
    {

    }
}