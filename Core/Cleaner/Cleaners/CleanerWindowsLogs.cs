public class CleanerWindowsLogs : Cleaner
{
    public CleanerWindowsLogs() : base("Windows Logs")
    {

    }

    public void Initialize()
    {
        this.SetCustomFind(true);
        this.SetCustomFindSostitutive(false);

        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Windows\Logs");
            this.AddDirectory(drive + @"\Windows\Debug");
            this.AddDirectory(drive + @"\Windows\System32\LogFiles\WMI");
            this.AddDirectory(drive + @"\Windows\security\logs");
            this.AddDirectory(drive + @"\Windows\ServiceProfiles\NetworkService\AppData\Local\Temp");
            this.AddFile(drive + @"\Windows\Microsoft.NET\Framework\v4.0.30319\ngen.log");
            this.AddFile(drive + @"\Windows\Microsoft.NET\Framework64\v4.0.30319\ngen.log");
            this.AddDirectory(drive + @"\ProgramData\Microsoft\Windows Defender\Support");
            this.AddDirectory(drive + @"\windows\serviceprofiles\networkservice\appdata\local\microsoft\windows\DeliveryOptimization\State");
            this.AddDirectory(drive + @"\Windows\Panther");
            this.AddDirectory(drive + @"\Windows\appcompat\Programs\Install");
            this.AddDirectory(drive + @"\Windows\System32\LogFiles");
            this.AddFile(drive + @"\Windows\System32\catroot2\dberr.txt");
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
                    if (System.IO.Directory.Exists(drive + @"\Windows\INF"))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(drive + @"\Windows\INF"))
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
                    if (System.IO.Directory.Exists(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Windows\WebCache"))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\Windows\WebCache"))
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
                    if (System.IO.Directory.Exists(drive + @"\programdata\microsoft\windows defender\scans"))
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            foreach (string file in System.IO.Directory.GetFiles(drive + @"\programdata\microsoft\windows defender\scans"))
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                try
                                {
                                    if (System.IO.Path.GetExtension(file).ToLower().Equals(".bin"))
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