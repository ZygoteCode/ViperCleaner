using Microsoft.Win32;

public class CleanerInternetExplorerCache : Cleaner
{
    public CleanerInternetExplorerCache() : base("Internet Explorer Cache", "Browsers")
    {

    }

    public void Initialize()
    {
        this.SetCustomClean(true);
        this.SetCustomCleanSostitutive(false);
        this.AddDirectory(Paths.InternetExplorerCookies);
        this.AddDirectory(Paths.InternetExplorerCookiesDomStore);
        this.AddDirectory(Paths.InternetExplorerHistory);
        this.AddFile(Paths.InternetExplorerIndexDat_1);
        this.AddFile(Paths.InternetExplorerIndexDat_2);
        this.AddFile(Paths.InternetExplorerIndexDat_3);
        this.AddFile(Paths.InternetExplorerIndexDat_4);
        this.AddFile(Paths.InternetExplorerIndexDat_5);
        this.AddFile(Paths.InternetExplorerIndexDat_6);
        this.AddDirectory(Paths.InternetExplorerTemps);
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {
        try
        {
            string keyPath64Bit = Paths.InternetExplorerRecentlyTypedUrls;
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey key64Bit = localMachine.OpenSubKey(keyPath64Bit, true);

            if (key64Bit != null)
            {
                var namesArray = key64Bit.GetValueNames();

                foreach (string valueName in namesArray)
                {
                    try
                    {
                        key64Bit.DeleteValue(valueName);
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
}