using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Text;
using System.Security.Cryptography;
using System;
using System.Linq;
using Microsoft.VisualBasic;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

public static class Utils
{
    private static bool isFinding;
    private static bool isCleaning;
    private static bool isOptimizing;
    private static bool isSpoofing;

    public static bool IsFinding()
    {
        return isFinding;
    }

    public static void SetIsFinding(bool finding)
    {
        isFinding = finding;
    }

    public static bool IsCleaning()
    {
        return isCleaning;
    }

    public static void SetIsCleaning(bool cleaning)
    {
        isCleaning = cleaning;
    }

    public static bool IsOptimizing()
    {
        return isOptimizing;
    }

    public static void SetOptimizing(bool optimizing)
    {
        isOptimizing = optimizing;
    }

    public static bool IsSpoofing()
    {
        return isSpoofing;
    }

    public static void SetSpoofing(bool spoofing)
    {
        isSpoofing = spoofing;
    }

    public static List<string> GetDrives()
    {
        List<string> drives = new List<string>();

        try
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    drives.Add(drive.Name.Substring(0, drive.Name.Length - 1));
                }
                catch
                {

                }
            }
        }
        catch
        {

        }

        return drives;
    }

    public static string GetSystemUser()
    {
        return Environment.UserName;
    }

    public static void RunCommand(string command)
    {
        using (var process = new Process())
        {
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Verb = "runas";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            try
            {
                process.PriorityClass = ProcessPriorityClass.RealTime;
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Close();
                process.WaitForExit();
            }
            catch
            {

            }
        }
    }

    public static void RunCommand(string command, string arguments)
    {
        using (var process = new Process())
        {
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Verb = "runas";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            try
            {
                process.PriorityClass = ProcessPriorityClass.RealTime;
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Close();
                process.WaitForExit();
            }
            catch
            {

            }
        }
    }

    public static string RunCommandReturn(string command)
    {
        using (var process = new Process())
        {
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            try
            {
                process.PriorityClass = ProcessPriorityClass.RealTime;
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Close();
                process.WaitForExit();

                return process.StandardOutput.ReadToEnd();
            }
            catch
            {

            }
        }

        return "";
    }

    public static void RunPowerShell(string command)
    {
        try
        {
            var process = new Process();
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.CreateNoWindow = true;
            processStartInfo.Arguments = command;
            processStartInfo.Verb = "runas";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.FileName = "powershell";
            process.StartInfo = processStartInfo;
            process.PriorityClass = ProcessPriorityClass.RealTime;
            process.Start();
            process.WaitForExit();
        }
        catch
        {

        }
    }

    public static void UnlockFileDelete(string path)
    {
        try
        {
            try
            {
                DeadLock.Classes.ListViewLocker locker = new DeadLock.Classes.ListViewLocker(path, 0);
                locker.Unlock();
            }
            catch
            {

            }

            try
            {
                if (File.GetAttributes(path).Equals(FileAttribute.Directory))
                {
                    System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);
                    info.Attributes = System.IO.FileAttributes.Directory;
                    System.IO.Directory.Delete(path);
                }
                else
                {
                    System.IO.File.SetAttributes(path, FileAttributes.Normal);
                    System.IO.File.Delete(path);
                }
            }
            catch
            {

            }
        }
        catch
        {

        }
    }

    public static string GetSHA1Hash()
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

        md5.ComputeHash(stream);

        stream.Close();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < md5.Hash.Length; i++)
        {
            sb.Append(md5.Hash[i].ToString("x2"));
        }

        return sb.ToString().ToUpperInvariant();
    }

    public static long GetFileLength()
    {
        System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        return stream.Length;
    }

    public static string GetUniqueID()
    {
        try
        {
            string id = "", theSerial = "", productID = "";

            try
            {
                ManagementObjectCollection mbsList = new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get();

                foreach (ManagementObject mo in mbsList)
                {
                    try
                    {
                        id = mo["ProcessorId"].ToString();
                        break;
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
                var query = new SelectQuery("select * from Win32_Bios");
                var search = new ManagementObjectSearcher(query);

                foreach (ManagementBaseObject item in search.Get())
                {
                    try
                    {
                        string serial = item["SerialNumber"] as string;

                        if (serial != null)
                        {
                            theSerial = serial;
                            break;
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
                RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
                productID = windowsNTKey.GetValue("ProductId").ToString();
            }
            catch
            {

            }

            string thing = EncryptAES256(id + theSerial + productID, "brMu348m").Replace("+", "X");

            if (thing == "")
            {
                Process.GetCurrentProcess().Kill();
                return "";
            }

            return thing;
        }
        catch
        {
            return "";
        }
    }

    private static string EncryptAES256(string input, string pass)
    {
        var AES = new RijndaelManaged();

        try
        {
            var hash = new byte[32];
            var temp = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(pass));

            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);

            AES.Key = hash;
            AES.Mode = CipherMode.ECB;

            var Buffer = Encoding.Unicode.GetBytes(input);

            return Convert.ToBase64String(AES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        catch
        {
            Process.GetCurrentProcess().Kill();

            return "";
        }
    }

    public static string smethod_9()
    {
        string right = Environment.SystemDirectory.Substring(0, 2) + "\\";
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");

        try
        {
            try
            {
                foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;

                    if (managementObject["Name"].ToString() == right)
                    {
                        return managementObject["DeviceID"].ToString().Substring(11, 36).Replace("-", "");
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

        return "";
    }

    public static string smethod_0(string string_0, string string_1)
    {
        string_0 = string.Join("", Enumerable.Repeat<string>(string_0, 10)).Substring(0, string_1.Length);
        string string_2 = smethod_3(smethod_1(string_0.smethod_2()), smethod_1(string_1.smethod_2()));
        int num = new Random().Next(80, 90);
        string text = num.ToString("X");
        int num2 = 1;

        checked
        {
            do
            {
                text += (num + num2).ToString("X");
                num2++;
            }
            while (num2 <= 31);

            string string_3 = num.ToString("X") + smethod_3(smethod_1(string_2.smethod_2()), smethod_1(text)).smethod_2();
            return smethod_1_1(string_3);
        }
    }

    public static string smethod_2(this string string_0)
    {
        return BitConverter.ToString(Encoding.Default.GetBytes(string_0)).Replace("-", "");
    }

    public static string smethod_3(string string_0, string string_1)
    {
        StringBuilder stringBuilder = new StringBuilder();

        checked
        {
            int num = string_1.Length - 1;

            for (int i = 0; i <= num; i++)
            {
                stringBuilder.Append(Strings.ChrW((int)(string_1[i] ^ string_0[i % string_0.Length])));
            }

            return stringBuilder.ToString();
        }
    }

    private static string smethod_1(string string_0)
    {
        if (string_0.Length % 2 == 1)
        {
            string_0 += "0";
        }

        checked
        {
            byte[] array = new byte[(int)Math.Round(unchecked((double)string_0.Length / 2.0 - 1.0)) + 1];
            int num = string_0.Length - 1;

            for (int i = 0; i <= num; i += 2)
            {
                array[(int)Math.Round((double)i / 2.0)] = Convert.ToByte(string_0.Substring(i, 2), 16);
            }

            return Encoding.Default.GetString(array);
        }
    }

    public static string smethod_1_1(string string_0)
    {
        StringBuilder stringBuilder = new StringBuilder();

        checked
        {
            int num = string_0.Length - 1;

            for (int i = 0; i <= num; i += 2)
            {
                string value = string_0.Substring(i, 2);
                stringBuilder.Append(Convert.ToChar(Convert.ToUInt32(value, 16)).ToString());
            }

            return stringBuilder.ToString();
        }
    }

    internal static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    internal static readonly char[] everything = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    internal static readonly char[] numbers = "123456789".ToCharArray();
    internal static readonly char[] charsToCheck = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#".ToCharArray();

    public static string GetUniqueKey(int size)
    {
        try
        {
            byte[] data = new byte[4 * size];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
        catch
        {
            return "";
        }
    }

    public static string GetUniqueKey1(int size)
    {
        try
        {
            byte[] data = new byte[4 * size];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % everything.Length;

                result.Append(everything[idx]);
            }

            return result.ToString();
        }
        catch
        {
            return "";
        }
    }

    public static long GetUniqueLong(int size)
    {
        try
        {
            byte[] data = new byte[4 * size];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % numbers.Length;

                result.Append(numbers[idx]);
            }

            return long.Parse(result.ToString());
        }
        catch
        {
            return 0L;
        }
    }
}