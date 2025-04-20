// ACleaner - Temp file scanning and cleaning software
// Copyright (C) 2011  Ernest Jr
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>

using System;
using System.IO;

internal static partial class Paths
{
    static Paths()
    {
    }

    #region  Base Path Methods 
    /// <summary>
    /// This method is only declared to make, making changes to all variables that require
    /// the AppData Roaming path, easier.
    /// </summary>
    /// <returns>Returns the user profile AppData Roaming path</returns>
    /// <remarks>ie: C:\Users\%USERPROFILE%\AppData\Roaming</remarks>
    private static string profileAppDataRoaming()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }

    /// <summary>
    /// User profile application data local path.
    /// </summary>
    /// <returns>AppData Local</returns>
    /// <remarks>N/A</remarks>
    private static string profileAppDataLocal()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }

    /// <summary>
    /// User profile application data local low path.
    /// </summary>
    /// <returns>Returns the user profile LocalLow AppData path</returns>
    /// <remarks>N/A</remarks>
    private static string profileAppDataLocalLow()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low";
    }

    /// <summary>
    /// System32
    /// </summary>
    /// <returns>Returns System32 path</returns>
    /// <remarks>N/A</remarks>
    private static string system32Path()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.System);
    }

    /// <summary>
    /// OS drive program data
    /// </summary>
    /// <returns>Returns the program data path</returns>
    /// <remarks>N/A</remarks>
    private static string programData()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    }

    /// <summary>
    /// OS drive path
    /// </summary>
    /// <returns>%OSDRIVE%\Windows</returns>
    /// <remarks>ie. C:\Windows</remarks>
    private static string osDriveWindows()
    {
        return Environment.GetEnvironmentVariable("WINDIR", EnvironmentVariableTarget.Machine);
    }

    /// <summary>
    /// OS drive
    /// </summary>
    /// <returns>Drive letter OS is installed on</returns>
    /// <remarks>Typically is C:\</remarks>
    private static string osDrive()
    {
        return system32Path().Substring(0, 3);
    }

    /// <summary>
    /// This method is used to identify the FF paths via the unique profile name
    /// </summary>
    /// <param name="pathType">Path type of path, ie: cookies, downloads, formhistory, cache</param>
    /// <returns></returns>
    /// <remarks></remarks>
    private static string mozillaFireFoxPaths(string pathType)
    {
        try
        {
            string rootPath = profileAppDataRoaming() + @"\Mozilla\Firefox\Profiles";
            string rootPath2 = profileAppDataLocal() + @"\Mozilla\Firefox\Profiles";
            if (Directory.Exists(rootPath))
            {
                var defaultProfilePaths = Directory.GetDirectories(rootPath, "*.default");
                foreach (var subfolderPath in defaultProfilePaths)
                {
                    switch (pathType ?? "")
                    {
                        case "cookies":
                            {
                                return subfolderPath + @"\cookies.sqlite";
                            }

                        case "webappsstore":
                            {
                                return subfolderPath + @"\webappsstore.sqlite";
                            }

                        case "downloads":
                            {
                                return subfolderPath + @"\downloads.sqlite";
                            }

                        case "formhistory":
                            {
                                return subfolderPath + @"\formhistory.sqlite";
                            }

                        case "cache":
                            {
                                var defaultProfilePaths2 = Directory.GetDirectories(rootPath2, "*.default");
                                foreach (var subfolderPath2 in defaultProfilePaths2)
                                    return subfolderPath2 + @"\cache";
                                break;
                            }

                        case "sessionstore.js":
                            {
                                return subfolderPath + @"\sessionstore.js";
                            }

                        case "sessionstore.bak":
                            {
                                return subfolderPath + @"\sessionstore.bak";
                            }

                        default:
                            {
                                throw new ArgumentException("Exception Occured. Invalid argument for mozillaFireFoxPaths method.");
                                break;
                            }
                    }
                }
            }
        }
        catch
        {

        }

        return default;
    }
    #endregion

    #region  Internet Explorer 
    /// <summary>
    /// Path to Internet Explorer's cookies
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string InternetExplorerCookies = profileAppDataRoaming() + @"\Microsoft\Windows\Cookies";
    /// <summary>
    /// Path to IE's cookies via DOM Store
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string InternetExplorerCookiesDomStore = profileAppDataLocalLow() + @"\Microsoft\Internet Explorer\DOMStore";
    /// <summary>
    /// Path to Internet Explorer's temp files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string InternetExplorerTemps = profileAppDataLocal() + @"\Microsoft\Windows\Temporary Internet Files";
    /// <summary>
    /// Path to Internet Explorer's history
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string InternetExplorerHistory = profileAppDataLocal() + @"\Microsoft\Windows\History";
    /// <summary>
    /// Path to Internet Explorer's recently typed URLs. See remarks.
    /// </summary>
    /// <remarks>IE's recently typed URLs are stored in the regstry, under HKCU.</remarks>
    public static string InternetExplorerRecentlyTypedUrls = @"SOFTWARE\Microsoft\Internet Explorer\TypedURLs";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_1 = profileAppDataRoaming() + @"\Microsoft\Windows\PrivacIE\index.dat";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_2 = profileAppDataRoaming() + @"\Microsoft\Windows\PrivacIE\Low\index.dat";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_3 = profileAppDataRoaming() + @"\Microsoft\Windows\IECompactCache\index.dat";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_4 = profileAppDataRoaming() + @"\Microsoft\Windows\IECompactCache\Low\index.dat";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_5 = profileAppDataRoaming() + @"\Microsoft\Windows\IETldCache\index.dat";
    /// <summary>
    /// Path to one of Internet Explorer's index.dat files
    /// </summary>
    /// <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    public static string InternetExplorerIndexDat_6 = profileAppDataRoaming() + @"\Microsoft\Windows\IETldCache\Low\index.dat";
    #endregion

    #region  Google Chrome 
    /// <summary>
    /// Path to Google Chrome's cookies. See Remarks.
    /// </summary>
    /// <remarks>This is NOT a directory and is instead a file with no extension. I think it's a SQLITE database.
    /// Either way, Chrome must be closed in order to delete this file and clear the cookies.</remarks>
    public static string GoogleChromeCookies = profileAppDataLocal() + @"\Google\Chrome\User Data\Default\Cookies";
    /// <summary>
    /// Path to Google Chrome's database cookies.
    /// </summary>
    /// <remarks>Search recursively - directory</remarks>
    public static string GoogleChromeCookiesDBs = profileAppDataLocal() + @"\Google\Chrome\User Data\Default\databases";
    /// <summary>
    /// Path to Google Chrome's local storage cookies.
    /// </summary>
    /// <remarks> Search non-recursively - directory</remarks>
    public static string GoogleChromeCookiesLocalStorage = profileAppDataLocal() + @"\Google\Chrome\User Data\Default\Local Storage";
    /// <summary>
    /// Path to Google Chrome's cache.
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string GoogleChromeCache = profileAppDataLocal() + @"\Google\Chrome\User Data\Default\Cache";
    /// <summary>
    /// Path to Google Chrome's history directory. See Remarks.
    /// </summary>
    /// <remarks>The history is contained in four different files that all contain the word "History" and must be deleted
    /// in order to clear all of chrome's history. They look something like "History Index 2011-00-journal", "History Index 2011-00", 
    /// "History", "History-journal". It's best to loop through each file in the directory, non-recursively, and filter for "History".</remarks>
    public static string GoogleChromeInternetHistory = profileAppDataLocal() + @"\Google\Chrome\User Data\Default";
    #endregion

    #region  Mozilla FireFox 
    /// <summary>
    /// Mozilla Firefox cookies path
    /// </summary>
    /// <remarks>Path is file not directory</remarks>
    public static string MozillaFireFoxCookies = mozillaFireFoxPaths("cookies");
    /// <summary>
    /// Mozilla Firefox
    /// </summary>
    /// <remarks>Path is file, not directory</remarks>
    public static string MozillaFireFoxCookiesWebAppsStore = mozillaFireFoxPaths("webappsstore");
    /// <summary>
    /// Mozilla Firefox Download history path
    /// </summary>
    /// <remarks>Path is file not directory</remarks>
    public static string MozillaFireFoxDownloads = mozillaFireFoxPaths("downloads");
    /// <summary>
    /// Mozilla Firefox form history path
    /// </summary>
    /// <remarks>Path is file not directory</remarks>
    public static string MozillaFireFoxFormHistory = mozillaFireFoxPaths("formhistory");
    /// <summary>
    /// Mozilla Firefox cache path
    /// </summary>
    /// <remarks>Path is directory, not path</remarks>
    public static string MozillaFireFoxCache = mozillaFireFoxPaths("cache");
    /// <summary>
    /// Mozilla Firefox session store path
    /// </summary>
    /// <remarks>Path is a file, not a directory</remarks>
    public static string MozillaFirefoxSessionStore = mozillaFireFoxPaths("sessionstore.js");
    /// <summary>
    /// Mozilla Firefox session store backup path
    /// </summary>
    /// <remarks>Path is a file, not a directory</remarks>
    public static string MozillaFirefoxSessionStoreBackup = mozillaFireFoxPaths("sessionstore.bak");
    #endregion

    #region  Safari 
    /// <summary>
    /// Safari cache path
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string SafariCache = profileAppDataRoaming() + @"\Apple Computer\Safari\Cache.db";
    /// <summary>
    /// Safari History list
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string SafariHistoryPlist = profileAppDataRoaming() + @"\Apple Computer\Safari\History.plist";
    /// <summary>
    /// Safari last session path
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string SafariHistoryLastSessionPlist = profileAppDataRoaming() + @"\Apple Computer\Safari\LastSession.plist";
    /// <summary>
    /// Safari History downloads list
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string SafariHistoryDownloadsPlist = profileAppDataRoaming() + @"\Apple Computer\Safari\Downloads.plist";
    /// <summary>
    /// Safari  History path
    /// </summary>
    /// <remarks>Directory</remarks>
    public static string SafariHistory = profileAppDataLocal() + @"\Apple Computer\Safari\History";
    /// <summary>
    /// Safari Webpage Previews
    /// </summary>
    /// <remarks>Directory</remarks>
    public static string SafariWebpagePreviews = profileAppDataLocal() + @"\Apple Computer\Safari\Webpage Previews";
    #endregion

    #region  Opera 
    /// <summary>
    /// Opera Cache
    /// </summary>
    /// <remarks>Search recursively</remarks>
    public static string OperaCache = profileAppDataLocal() + @"\Opera\Opera\cache";
    /// <summary>
    /// Opera OP Cache
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string OperaOPCache = profileAppDataLocal() + @"\Opera\Opera\opcache";
    /// <summary>
    /// Opera Icon Cache
    /// </summary>
    /// <remarks>Search recursively</remarks>
    public static string OperaIconCache = profileAppDataLocal() + @"\Opera\Opera\icons\cache";
    /// <summary>
    /// Opera Internet History
    /// </summary>
    /// <remarks>Search recursively</remarks>
    public static string OperaInternetHistory_1 = profileAppDataLocal() + @"\Opera\Opera\vps";
    /// <summary>
    /// Opera Internet History - DAT Files
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaInternetHistory_2 = profileAppDataRoaming() + @"\Opera\Opera\global_history.dat";
    /// <summary>
    /// Opera Internet History
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaInternetHistory_3 = profileAppDataRoaming() + @"\Opera\Opera\download.dat";
    /// <summary>
    /// Opera Internet History
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaInternetHistory_4 = profileAppDataRoaming() + @"\Opera\Opera\vlink4.dat";
    /// <summary>
    /// Opera Internet History
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaInternetHistory_5 = profileAppDataRoaming() + @"\Opera\Opera\typed_history.xml";
    /// <summary>
    /// Opera Internet History
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaInternetHistory_6 = profileAppDataRoaming() + @"\Opera\Opera\sessions\autosave.win";
    /// <summary>
    /// Opera Cookies
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string OperaCookies = profileAppDataRoaming() + @"\Opera\Opera\cookies4.dat";
    /// <summary>
    /// Opera Website Icons
    /// </summary>
    /// <remarks>Do not recurse</remarks>
    public static string OperaWebsiteIcon = profileAppDataLocal() + @"\icons";
    /// <summary>
    /// Opera Temporary Downloads - Download History
    /// </summary>
    /// <remarks></remarks>
    public static string OperaCacheTempDownloads = profileAppDataLocal() + @"\Opera\Opera\temporary_downloads";
    #endregion

    #region  Internet - uTorrent, Java 
    /// <summary>
    /// Main uTorrent temp files. Typically "resume.dat.old" and "settings.dat.old"
    /// </summary>
    /// <remarks>Filter with *.old</remarks>
    public static string uTorrentTempFiles = profileAppDataRoaming() + @"\uTorrent";
    /// <summary>
    /// uTorrent DLL Image Cache
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string uTorrentDllImageCache = profileAppDataRoaming() + @"\uTorrent\dllimagecache";
    /// <summary>
    /// Sun Java Cache
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string SunJavaCache = profileAppDataLocalLow() + @"\Sun\Java\Deployment\cache\6.0";
    /// <summary>
    /// Sun Java System Cache
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string SunJavaSystemCache = profileAppDataLocalLow() + @"\Sun\Java\Deployment\SystemCache\6.0";
    /// <summary>
    /// FileZilla Recent Server List
    /// </summary>
    /// <remarks>File, not directory</remarks>
    public static string FileZillaRecentServers = profileAppDataRoaming() + @"\FileZila\recentservers.xml";
    #endregion

    #region  Antivirus 
    /// <summary>
    /// AVG Antivirus 10 log files.
    /// </summary>
    /// <remarks>Filter for .log and .xml files</remarks>
    public static string AvgAntivirus10Log = programData() + @"\avg10\Log";
    /// <summary>
    /// AVG Antivirus 10 backup files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string AvgAntivirus10Backup = programData() + @"\avg10\update\backup";
    /// <summary>
    /// AVG Antivirus 10 misc files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string AvgAntivirus10Misc = programData() + @"\avg10\IDS\profile";
    /// <summary>
    /// AVG Antivirus 10 temp files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string AvgAntivirus10Temps = programData() + @"\avg10\Temp";

    /// <summary>
    /// MalwareBytes log files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string MalwareBytesLogs = profileAppDataRoaming() + @"\Malwarebytes\Malwarebytes' Anti-Malware\Logs";
    /// <summary>
    /// MalwareBytes backup files
    /// </summary>
    /// <remarks>Filter for "BACKUP" and "QUAR" files</remarks>
    public static string MalwareBytesQuarantineBackup = profileAppDataRoaming() + @"\Malwarebytes\Malwarebytes' Anti-Malware\Quarantine";

    /// <summary>
    /// Windows Defender quick history
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsDefenderHistoryQuick = programData() + @"\Microsoft\Windows Defender\Scans\History\Results\Quick";
    /// <summary>
    /// Windows Defender resource history
    /// </summary>
    /// <remarks></remarks>
    public static string WindowsDefenderHistoryResource = programData() + @"\Microsoft\Windows Defender\Scans\History\Results\Resource";

    /// <summary>
    /// Spybot SD log files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string SpybotSdLogs = programData() + @"\Spybot - Search & Destroy\Logs";
    /// <summary>
    /// Spybot SD statistics ini file
    /// </summary>
    /// <remarks>This is a file, not a directory</remarks>
    public static string SpybotSdIni = programData() + @"\Spybot - Search & Destroy\Statistics.ini";
    /// <summary>
    /// Spybot SD Backup files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string SpybotSdBackups = programData() + @"\Spybot - Search & Destroy\Backups";
    #endregion

    #region  Windows Explorer 
    /// <summary>
    /// Windows Explorer recent files list
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsExplorerRecent = profileAppDataRoaming() + @"\Microsoft\Windows\Recent";
    /// <summary>
    /// Windows Explorer thumbnail cache
    /// </summary>
    /// <remarks></remarks>
    public static string WindowsExplorerThumbnailCache = profileAppDataLocal() + @"\MICROSOFT\Windows\Explorer";
    #endregion

    #region  System 
    /// <summary>
    /// Windows system temp
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsTempFiles = osDriveWindows() + @"\Temp";
    /// <summary>
    /// User temp files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string UserTemps = profileAppDataLocal() + @"\Temp";
    /// <summary>
    /// ChkDsk file fragments
    /// </summary>
    /// <remarks>Filter with *.chk</remarks>
    public static string ChkDskFileFragments = osDrive().Substring(0, 1);

    /// <summary>
    /// Windows log files
    /// </summary>
    /// <remarks>Filter with *.log</remarks>
    public static string WindowsLogFiles = osDrive().Substring(0, 1);
    /// <summary>
    /// Windows error reporting files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsErrorReporting_1 = profileAppDataLocal() + @"\Microsoft\Windows\WER\ReportArchive";
    /// <summary>
    /// Windows error reporting files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsErrorReporting_2 = profileAppDataLocal() + @"\Microsoft\Windows\WER\ReportQueue";
    /// <summary>
    /// Windows error reporting files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsErrorReporting_3 = programData() + @"\Windows\WER\ReportArchive";
    /// <summary>
    /// Windows error reporting files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsErrorReporting_4 = programData() + @"\Microsoft\Windows\WER\ReportQueue";
    #endregion

    #region  Advanced 
    /// <summary>
    /// Windows prefetch data
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string PrefetchData = @"C:\Windows\Prefetch";

    #endregion

    #region  Media 
    /// <summary>
    /// Windows Media Player temp files
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string WindowsMediaPlayer = profileAppDataLocal() + @"\Microsoft\Media Player";
    /// <summary>
    /// Quick Time player cache
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string QuickTimePlayerCache = profileAppDataLocalLow() + @"\Apple Computer\QuickTime\downloads";
    /// <summary>
    /// QT session data
    /// </summary>
    /// <remarks>Handle as file, not directory</remarks>
    public static string QuickTimerPlayer = profileAppDataLocalLow() + @"\Apple Computer\QuickTime\QTPlayerSession.xml";
    /// <summary>
    /// Adobe Flash Player
    /// </summary>
    /// <remarks>N/A</remarks>
    public static string AdobeFlashPlayer = profileAppDataRoaming() + @"\Macromedia";
    #endregion

    #region  Misc Applications 
    /// <summary>
    /// Paint.Net temp files
    /// </summary>
    /// <remarks>Recurse through each folder in this directory.</remarks>
    public static string PaintNet = profileAppDataLocal() + @"\Paint.NET";
    #endregion

    #region  Visual Studio 
    /// <summary>
    /// VS 2010 File MRU List
    /// </summary>
    /// <remarks>HKCU</remarks>
    public static string VisualStudio2010FileMRUList = @"SOFTWARE\Microsoft\VisualStudio\10.0\FileMRUList";
    /// <summary>
    /// VS 2010 Project MRU List
    /// </summary>
    /// <remarks>HKCU</remarks>
    public static string VisualStudio2010ProjectMRUList = @"SOFTWARE\Microsoft\VisualStudio\10.0\ProjectMRUList";
    /// <summary>
    /// VS 2008 File MRU List
    /// </summary>
    /// <remarks></remarks>
    public static string VisualStudio2008FileMRUList = @"SOFTWARE\Microsoft\VisualStudio\9.0\FileMRUList";
    /// <summary>
    /// VS 2008 Project MRU List
    /// </summary>
    /// <remarks>HKCU</remarks>
    public static string VisualStudio2008ProjectMRUList = @"SOFTWARE\Microsoft\VisualStudio\9.0\ProjectMRUList";
    /// <summary>
    /// VS 2005 File MRU List
    /// </summary>
    /// <remarks></remarks>
    public static string VisualStudio2005FileMRUList = @"SOFTWARE\Microsoft\VisualStudio\8.0\FileMRUList";
    /// <summary>
    /// VS 2005 Project MRU List
    /// </summary>
    /// <remarks>HKCU</remarks>
    public static string VisualStudio2005ProjectMRUList = @"SOFTWARE\Microsoft\VisualStudio\8.0\ProjectMRUList";
    #endregion

}