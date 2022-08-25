public class CleanerDirectXShaderCache : Cleaner
{
    public CleanerDirectXShaderCache() : base("DirectX Shader Cache")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\D3DSCache");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}