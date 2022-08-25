using System.Collections.Generic;
using ns1;
using MetroSuite;
using System;

public class Cleaner
{
    private string name;
    private string category;
    private List<string> directories;
    private List<string> files;
    private List<string> foundFiles;
    private List<string> foundDirectories;
    private SiticoneCheckBox parentCheckBox;
    private MetroLabel parentNameLabel;
    private MetroLabel parentCategoryLabel;
    private MetroLabel parentFilesLabel;
    private MetroLabel parentCleanedLabel;
    private int cleanedFiles;
    private bool findingCompleted;
    private bool cleaningCompleted;
    private bool customClean;
    private bool customCleanSostitutive;
    private bool customFind;
    private bool customFindSostitutive;

    public Cleaner(string name, string category = "Windows")
    {
        this.name = name;
        this.category = category;
        this.files = new List<string>();
        this.directories = new List<string>();
        this.foundFiles = new List<string>();
        this.foundDirectories = new List<string>();
    }

    public void SetCustomClean(bool customClean)
    {
        this.customClean = customClean;
    }

    public bool IsCustomClean()
    {
        return this.customClean;
    }

    public void SetCustomCleanSostitutive(bool customCleanSostitutive)
    {
        this.customCleanSostitutive = customCleanSostitutive;
    }

    public bool IsCustomCleanSostitutive()
    {
        return this.customCleanSostitutive;
    }

    public void SetCustomFind(bool customFind)
    {
        this.customFind = customFind;
    }

    public bool IsCustomFind()
    {
        return this.customFind;
    }

    public void SetCustomFindSostitutive(bool customFindSostitutive)
    {
        this.customFindSostitutive = customFindSostitutive;
    }

    public bool IsCustomFindSostitutive()
    {
        return this.customFindSostitutive;
    }

    public bool IsFindingCompleted()
    {
        return this.findingCompleted;
    }

    public void SetFindingCompleted(bool findingCompleted)
    {
        this.findingCompleted = findingCompleted;
    }

    public bool IsCleaningCompleted()
    {
        return this.cleaningCompleted;
    }

    public void SetCleaningCompleted(bool cleaningCompleted)
    {
        this.cleaningCompleted = cleaningCompleted;
    }

    public void SetParentNameLabel(MetroLabel label)
    {
        this.parentNameLabel = label;
    }

    public void SetParentCategoryLabel(MetroLabel label)
    {
        this.parentCategoryLabel = label;
    }

    public void SetParentFilesLabel(MetroLabel label)
    {
        this.parentFilesLabel = label;
    }

    public void SetParentCleanedLabel(MetroLabel label)
    {
        this.parentCleanedLabel = label;
    }

    public MetroLabel GetParentNameLabel()
    {
        return this.parentNameLabel;
    }

    public MetroLabel GetParentCategoryLabel()
    {
        return this.parentCategoryLabel;
    }

    public MetroLabel GetParentFilesLabel()
    {
        return this.parentFilesLabel;
    }

    public MetroLabel GetParentCleanedLabel()
    {
        return this.parentCleanedLabel;
    }

    public string GetCategory()
    {
        return this.category;
    }

    public void SetCategory(string category)
    {
        this.category = category;
        this.GetParentCategoryLabel().Text = category;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string name)
    {
        this.name = name;
        this.GetParentNameLabel().Text = name;
    }

    public List<string> GetDirectories()
    {
        return this.directories;
    }

    public void AddDirectory(string directory)
    {
        this.directories.Add(directory);
    }

    public void RemoveDirectory(string directory)
    {
        this.directories.Remove(directory);
    }

    public List<string> GetFiles()
    {
        return this.files;
    }

    public void AddFile(string file)
    {
        this.files.Add(file);
    }

    public void RemoveFile(string file)
    {
        this.files.Remove(file);
    }

    public List<string> GetFoundFiles()
    {
        return this.foundFiles;
    }

    public void AddFoundFile(string foundFile)
    {
        this.foundFiles.Add(foundFile);
    }

    public void RemoveFoundFile(string foundFile)
    {
        this.foundFiles.Remove(foundFile);
    }

    public void ClearFoundFiles()
    {
        this.foundFiles.Clear();
        this.GetParentFilesLabel().Text = "0";
    }

    public List<string> GetFoundDirectories()
    {
        return this.foundDirectories;
    }

    public void AddFoundDirectory(string foundDirectory)
    {
        this.foundDirectories.Add(foundDirectory);
    }

    public void RemoveFoundDirectory(string foundDirectory)
    {
        this.foundDirectories.Remove(foundDirectory);
    }

    public void ClearFoundDirectories()
    {
        this.foundDirectories.Clear();
    }

    public void SetParentCheckBox(SiticoneCheckBox checkBox)
    {
        this.parentCheckBox = checkBox;
    }

    public SiticoneCheckBox GetParentCheckBox()
    {
        return this.parentCheckBox;
    }

    public void SetCleanedFiles(int cleanedFiles)
    {
        this.cleanedFiles = cleanedFiles;
        //this.GetParentCleanedLabel().Text = this.cleanedFiles.ToString();
    }

    public int GetCleanedFiles()
    {
        return this.cleanedFiles;
    }

    public void ClearFiles()
    {
        this.files.Clear();
    }

    public void ResetCleanedFiles()
    {
        this.cleanedFiles = 0;
        this.GetParentCleanedLabel().Text = "0";
    }

    public void ClearDirectories()
    {
        this.directories.Clear();
    }

    public void FindForFiles()
    {
        try
        {
            if (!Utils.IsFinding())
            {
                return;
            }

            this.ClearFoundFiles();
            this.ClearFoundDirectories();

            this.SetFindingCompleted(false);
            this.SetCleaningCompleted(false);

            if (!Utils.IsFinding())
            {
                return;
            }

            try
            {
                foreach (string file in files)
                {
                    if (!Utils.IsFinding())
                    {
                        return;
                    }

                    try
                    {
                        if (System.IO.File.Exists(file))
                        {
                            if (!Utils.IsFinding())
                            {
                                return;
                            }

                            this.AddFoundFile(file);
                        }

                        if (!Utils.IsFinding())
                        {
                            return;
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

            if (!Utils.IsFinding())
            {
                return;
            }

            try
            {
                foreach (string directory in directories)
                {
                    if (!Utils.IsFinding())
                    {
                        return;
                    }

                    try
                    {
                        if (System.IO.Directory.Exists(directory))
                        {
                            if (!Utils.IsFinding())
                            {
                                return;
                            }

                            this.AddFoundDirectory(directory);

                            try
                            {
                                try
                                {
                                    if (!Utils.IsFinding())
                                    {
                                        return;
                                    }

                                    foreach (string file in System.IO.Directory.GetFiles(directory))
                                    {
                                        try
                                        {
                                            if (!Utils.IsFinding())
                                            {
                                                return;
                                            }

                                            this.AddFoundFile(file);
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                catch
                                {

                                }

                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                LoadSubDirectories(directory);

                                if (!Utils.IsFinding())
                                {
                                    return;
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

            if (!Utils.IsFinding())
            {
                return;
            }

            try
            {
                List<string> reversedDirectories = this.GetFoundDirectories();
                reversedDirectories.Reverse();

                if (!Utils.IsFinding())
                {
                    return;
                }

                try
                {
                    foreach (string dir in reversedDirectories)
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        try
                        {
                            if (System.IO.Directory.Exists(dir))
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                try
                                {
                                    this.AddFoundDirectory(dir);
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
            catch
            {

            }

            this.SetFindingCompleted(true);
            this.SetCleaningCompleted(false);
        }
        catch
        {

        }
    }

    private void LoadSubDirectories(string directory)
    {
        try
        {
            if (!Utils.IsFinding())
            {
                return;
            }

            foreach (string dir in System.IO.Directory.GetDirectories(directory))
            {
                if (!Utils.IsFinding())
                {
                    return;
                }

                this.AddFoundDirectory(dir);

                try
                {
                    try
                    {
                        if (!Utils.IsFinding())
                        {
                            return;
                        }

                        foreach (string file in System.IO.Directory.GetFiles(dir))
                        {
                            try
                            {
                                if (!Utils.IsFinding())
                                {
                                    return;
                                }

                                this.AddFoundFile(file);
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {

                    }

                    if (!Utils.IsFinding())
                    {
                        return;
                    }

                    LoadSubDirectories(dir);

                    if (!Utils.IsFinding())
                    {
                        return;
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

    public void CleanFiles()
    {
        try
        {
            this.SetFindingCompleted(false);
            this.SetCleaningCompleted(false);

            if (!Utils.IsCleaning())
            {
                return;
            }

            this.ResetCleanedFiles();

            if (!Utils.IsCleaning())
            {
                return;
            }

            foreach (string file in foundFiles)
            {
                if (!Utils.IsCleaning())
                {
                    return;
                }

                try
                {
                    if (System.IO.File.Exists(file))
                    {
                        if (!Utils.IsCleaning())
                        {
                            return;
                        }

                        try
                        {
                            if (!Utils.IsCleaning())
                            {
                                return;
                            }

                            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
                            System.IO.File.Delete(file);

                            if (!Utils.IsCleaning())
                            {
                                return;
                            }

                            this.SetCleanedFiles(this.GetCleanedFiles() + 1);

                            if (!Utils.IsCleaning())
                            {
                                return;
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

            if (!Utils.IsCleaning())
            {
                return;
            }

            try
            {
                foreach (string dir in this.GetFoundDirectories())
                {
                    if (!Utils.IsCleaning())
                    {
                        return;
                    }

                    try
                    {
                        if (System.IO.Directory.Exists(dir))
                        {
                            if (!Utils.IsCleaning())
                            {
                                return;
                            }

                            try
                            {
                                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(dir);
                                info.Attributes = System.IO.FileAttributes.Directory;
                                System.IO.Directory.Delete(dir, true);
                                this.RemoveFoundDirectory(dir);
                            }
                            catch
                            {

                            }

                            if (!Utils.IsCleaning())
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

            this.SetFindingCompleted(false);
            this.SetCleaningCompleted(true);
        }
        catch
        {

        }
    }
}