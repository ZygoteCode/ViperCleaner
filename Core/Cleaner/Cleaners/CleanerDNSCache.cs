using System;
using System.Runtime.InteropServices;

public class CleanerDNSCache : Cleaner
{
    [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
    private static extern UInt32 DnsFlushResolverCache();

    public CleanerDNSCache() : base("DNS Cache", "Network")
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
        DnsFlushResolverCache();
        this.SetCleaningCompleted(true);
    }
}