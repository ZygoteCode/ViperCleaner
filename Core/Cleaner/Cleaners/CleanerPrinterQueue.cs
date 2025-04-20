public class CleanerPrinterQueue : Cleaner
{
    public CleanerPrinterQueue() : base("Printer Queue")
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
        Utils.RunCommand("net stop spooler");
        Utils.RunCommand(@"del %systemroot%\System32\spool\printers\* /Q");
        Utils.RunCommand("net start spooler");
        this.SetCleaningCompleted(true);
    }
}