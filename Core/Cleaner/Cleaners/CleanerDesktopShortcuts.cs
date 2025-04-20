public class CleanerDesktopShortcuts : Cleaner
{
    public CleanerDesktopShortcuts() : base("Desktop Shortcuts")
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
        this.SetFindingCompleted(false);

        try
        {
            if (!Utils.IsFinding())
            {
                return;
            }

            foreach (string file in System.IO.Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)))
            {
                if (!Utils.IsFinding())
                {
                    return;
                }

                try
                {
                    if (System.IO.Path.GetExtension(file).ToLower().Equals(".lnk"))
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

        this.SetFindingCompleted(true);
    }

    public void CustomCleanFiles()
    {

    }
}