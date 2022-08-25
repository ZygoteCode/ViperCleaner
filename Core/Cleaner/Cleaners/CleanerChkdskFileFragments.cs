public class CleanerChkdskFileFragments : Cleaner
{
    public CleanerChkdskFileFragments() : base("Chkdsk File Fragments")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(true);

        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser());
        }
    }

    public void CustomFindForFiles()
    {
        this.ClearFoundFiles();
        this.SetFindingCompleted(false);

        try
        {
            if (!Utils.IsFinding())
            {
                return;
            }

            try
            {
                foreach (string dir in this.GetDirectories())
                {
                    if (!Utils.IsFinding())
                    {
                        return;
                    }

                    if (System.IO.Directory.Exists(dir))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(dir))
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                try
                                {
                                    if (System.IO.Path.GetExtension(file).ToLower().Equals(".chk"))
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
            }
            catch
            {

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