using System.Collections.Generic;
using Guna.UI.WinForms;
using System.Drawing;

public class CleanerManager
{
    private List<Cleaner> cleaners;
    private GunaVSeparator parentSeparator1;
    private GunaVSeparator parentSeparator2;
    private GunaVSeparator parentSeparator3;

    public CleanerManager()
    {
        this.cleaners = new List<Cleaner>();
    }

    public List<Cleaner> GetCleaners()
    {
        return this.cleaners;
    }

    public void AddCleaner(Cleaner cleaner)
    {
        cleaner.GetType().GetMethod("Initialize").Invoke(cleaner, new object[] { });
        this.cleaners.Add(cleaner);

        if (this.cleaners.Count >= 22)
        {
            this.GetParentSeparator1().Size = new Size(this.GetParentSeparator1().Width, this.GetParentSeparator1().Height + 20);
            this.GetParentSeparator2().Size = new Size(this.GetParentSeparator2().Width, this.GetParentSeparator2().Height + 20);
            this.GetParentSeparator3().Size = new Size(this.GetParentSeparator3().Width, this.GetParentSeparator3().Height + 20);
        }
    }

    public void RemoveCleaner(Cleaner cleaner)
    {
        this.cleaners.Remove(cleaner);
    }

    public void AddCleaner(string name)
    {
        Cleaner cleaner = new Cleaner(name);
        AddCleaner(cleaner);
    }

    public void RemoveCleaner(string name)
    {
        foreach (Cleaner cleaner in cleaners)
        {
            if (cleaner.GetName().Equals(name))
            {
                this.cleaners.Remove(cleaner);
                break;
            }
        }
    }

    public Cleaner GetCleaner(string name)
    {
        foreach (Cleaner cleaner in cleaners)
        {
            if (cleaner.GetName().Equals(name))
            {
                return cleaner;
            }
        }

        return null;
    }

    public void SetParentSeparator1(GunaVSeparator separator)
    {
        this.parentSeparator1 = separator;
    }

    public void SetParentSeparator2(GunaVSeparator separator)
    {
        this.parentSeparator2 = separator;
    }

    public void SetParentSeparator3(GunaVSeparator separator)
    {
        this.parentSeparator3 = separator;
    }

    public GunaVSeparator GetParentSeparator1()
    {
        return this.parentSeparator1;
    }

    public GunaVSeparator GetParentSeparator2()
    {
        return this.parentSeparator2;
    }

    public GunaVSeparator GetParentSeparator3()
    {
        return this.parentSeparator3;
    }

    public void AddCleaners()
    {
        this.AddCleaner(new CleanerPrefetch());
        this.AddCleaner(new CleanerArchiveTemp());
        this.AddCleaner(new CleanerTemp());
        this.AddCleaner(new CleanerInstallCache());
        this.AddCleaner(new CleanerWindowsLogs());
        this.AddCleaner(new CleanerSoftwareDistribution());
        this.AddCleaner(new CleanerFontCache());
        this.AddCleaner(new CleanerLocalLow());
        this.AddCleaner(new CleanerCrashDumps());
        this.AddCleaner(new CleanerReportArchive());
        this.AddCleaner(new CleanerKernelReports());
        this.AddCleaner(new CleanerMemoryDumps());
        this.AddCleaner(new CleanerChkdskFileFragments());
        this.AddCleaner(new CleanerMinecraftLogs());
        this.AddCleaner(new CleanerSteamLogs());
        this.AddCleaner(new CleanerPackageCache());
        this.AddCleaner(new CleanerSystemTempFiles());
        this.AddCleaner(new CleanerThumbnailCache());
        this.AddCleaner(new CleanerIISLogs());
        this.AddCleaner(new CleanerDesktopShortcuts());
        this.AddCleaner(new CleanerDownloadFolder());
        this.AddCleaner(new CleanerCLR());
        this.AddCleaner(new CleanerDNSCache());
        this.AddCleaner(new CleanerWindowsEventLogs());
        this.AddCleaner(new CleanerHostsFile());
        this.AddCleaner(new CleanerUserAssistHistory());
        this.AddCleaner(new CleanerWinSock());
        this.AddCleaner(new CleanerTCPIP());
        this.AddCleaner(new CleanerBITS());
        this.AddCleaner(new CleanerFirewall());
        this.AddCleaner(new CleanerPrinterQueue());
        this.AddCleaner(new CleanerStartMenuShortcuts());
        this.AddCleaner(new CleanerGoogleChromeCache());
        this.AddCleaner(new CleanerFirefoxCache());
        this.AddCleaner(new CleanerOperaCache());
        this.AddCleaner(new CleanerSafariCache());
        this.AddCleaner(new CleanerMicrosoftEdgeCache());
        this.AddCleaner(new CleanerInternetExplorerCache());
        this.AddCleaner(new CleanerINetCache());
        this.AddCleaner(new CleanerMediaTemp());
        this.AddCleaner(new CleanerExplorerCache());
        this.AddCleaner(new CleanerAntivirusTemp());
        this.AddCleaner(new CleanerApplicationsTemp());
        this.AddCleaner(new CleanerGamesLogs());
        this.AddCleaner(new CleanerDirectXShaderCache());
        this.AddCleaner(new CleanerOptimizationLogs());
        this.AddCleaner(new CleanerDriverPackages());
    }
}