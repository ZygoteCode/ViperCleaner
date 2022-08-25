public class CleanerCLR : Cleaner
{
    public CleanerCLR() : base("CLR")
    {

    }

    public void Initialize()
    {
        foreach (string drive in Utils.GetDrives())
        {
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v1.0");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v1.0_32");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v2.0");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v2.0_32");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v3.0");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v3.0_32");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v4.0");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v4.0_32");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v5.0");
            this.AddDirectory(drive + @"\Users\" + Utils.GetSystemUser() + @"\AppData\Local\Microsoft\CLR_v5.0_32");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v1.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v1.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v1.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v1.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v2.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v2.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v2.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v2.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v3.0");
            this.AddDirectory(drive + @"\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v3.0_32");
            this.AddDirectory(drive + @"\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v3.0_32");
        }
    }

    public void CustomFindForFiles()
    {

    }

    public void CustomCleanFiles()
    {

    }
}