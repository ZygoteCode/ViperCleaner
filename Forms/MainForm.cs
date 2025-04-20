using System.Windows.Forms;
using System.Diagnostics;
using MetroSuite;
using ns1;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Runtime;
using System.Security.Principal;

public partial class MainForm : MetroForm
{
    private CleanerManager cleanerManager;
    private OptimizerManager optimizerManager;
    private SpooferManager spooferManager;

    [DllImport("psapi.dll")]
    static extern int EmptyWorkingSet(IntPtr hwProc);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetProcessWorkingSetSize(IntPtr process, UIntPtr minimumWorkingSetSize, UIntPtr maximumWorkingSetSize);

    public MainForm()
    {
        InitializeComponent();

        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        
        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
        {
            Process.GetCurrentProcess().Kill();
            return;
        }

        this.cleanerManager = new CleanerManager();
        this.cleanerManager.SetParentSeparator1(this.gunaVSeparator1);
        this.cleanerManager.SetParentSeparator2(this.gunaVSeparator2);
        this.cleanerManager.SetParentSeparator3(this.gunaVSeparator3);
        this.cleanerManager.AddCleaners();

        this.optimizerManager = new OptimizerManager();
        this.optimizerManager.SetParentSeparator1(this.gunaVSeparator6);
        this.optimizerManager.SetParentSeparator2(this.gunaVSeparator4);
        this.optimizerManager.AddOptimizers();

        this.spooferManager = new SpooferManager();
        this.spooferManager.SetParentSeparator1(this.gunaVSeparator7);
        this.spooferManager.SetParentSeparator2(this.gunaVSeparator5);
        this.spooferManager.AddSpoofers();

        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        CheckForIllegalCrossThreadCalls = false;

        int posX = 11, posY = 11;

        {

            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerSelectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Select All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            panel1.Controls.Add(checkBox);
            posY += 23;
        }

        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerUnselectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Unselect All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged1;

            panel1.Controls.Add(checkBox);
            posY += 46;
        }

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticone" + cleaner.GetName().Replace(" ", "_");
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = cleaner.GetName();
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;

            cleaner.SetParentCheckBox(checkBox);

            panel1.Controls.Add(checkBox);
            posY += 23;
        }

        posX = 11;
        posY = 33;

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Name_" + cleaner.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = cleaner.GetName();

            cleaner.SetParentNameLabel(label);

            panel2.Controls.Add(label);
            posY += 21;
        }

        posX = 189;
        posY = 33;

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Category_" + cleaner.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = cleaner.GetCategory();

            cleaner.SetParentCategoryLabel(label);

            panel2.Controls.Add(label);
            posY += 21;
        }

        posX = 384;
        posY = 33;

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Files_" + cleaner.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = "0";

            cleaner.SetParentFilesLabel(label);

            panel2.Controls.Add(label);
            posY += 21;
        }

        posX = 530;
        posY = 33;

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Cleaned_" + cleaner.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = "0";

            cleaner.SetParentCleanedLabel(label);

            panel2.Controls.Add(label);
            posY += 21;
        }

        posX = 11;
        posY = 11;

        {

            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerSelectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Select All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged4;

            panel3.Controls.Add(checkBox);
            posY += 23;
        }

        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerUnselectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Unselect All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged5;

            panel3.Controls.Add(checkBox);
            posY += 46;
        }

        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticone" + optimizer.GetName().Replace(" ", "_");
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = optimizer.GetName();
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;

            optimizer.SetParentCheckBox(checkBox);

            panel3.Controls.Add(checkBox);
            posY += 23;
        }

        posX = 11;
        posY = 33;

        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Name_" + optimizer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = optimizer.GetName();

            optimizer.SetParentNameLabel(label);

            panel4.Controls.Add(label);
            posY += 21;
        }

        posX = 238;
        posY = 33;

        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Category_" + optimizer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = optimizer.GetCategory();

            optimizer.SetParentCategoryLabel(label);

            panel4.Controls.Add(label);
            posY += 21;
        }

        posX = 458;
        posY = 33;

        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Status_" + optimizer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = optimizer.GetStatus();

            optimizer.SetParentStatusLabel(label);

            panel4.Controls.Add(label);
            posY += 21;
        }

        posX = 11;
        posY = 11;

        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerSelectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Select All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged2;

            panel6.Controls.Add(checkBox);
            posY += 23;
        }

        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticoneCleanerUnselectAll";
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = "Unselect All";
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged3;

            panel6.Controls.Add(checkBox);
            posY += 46;
        }

        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            SiticoneCheckBox checkBox = new SiticoneCheckBox();

            checkBox.AutoSize = true;
            checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.CheckedState.BorderRadius = 2;
            checkBox.CheckedState.BorderThickness = 0;
            checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            checkBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Location = new System.Drawing.Point(posX, posY);
            checkBox.Name = "siticone" + spoofer.GetName().Replace(" ", "_");
            checkBox.Size = new System.Drawing.Size(79, 17);
            checkBox.Text = spoofer.GetName();
            checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UncheckedState.BorderRadius = 2;
            checkBox.UncheckedState.BorderThickness = 0;
            checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            checkBox.UseVisualStyleBackColor = true;

            spoofer.SetParentCheckBox(checkBox);

            panel6.Controls.Add(checkBox);
            posY += 23;
        }

        posX = 11;
        posY = 33;

        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Name_" + spoofer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = spoofer.GetName();

            spoofer.SetParentNameLabel(label);

            panel5.Controls.Add(label);
            posY += 21;
        }

        posX = 238;
        posY = 33;

        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Category_" + spoofer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = spoofer.GetCategory();

            spoofer.SetParentCategoryLabel(label);

            panel5.Controls.Add(label);
            posY += 21;
        }

        posX = 458;
        posY = 33;

        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            MetroLabel label = new MetroLabel();

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(posX, posY);
            label.Name = "metroLabel_Status_" + spoofer.GetName().Replace(" ", "_");
            label.Size = new System.Drawing.Size(62, 15);
            label.Text = spoofer.GetStatus();

            spoofer.SetParentStatusLabel(label);

            panel5.Controls.Add(label);
            posY += 21;
        }

        Thread waitForFinishingThread = new Thread(WaitForFinishing);
        waitForFinishingThread.Priority = ThreadPriority.Highest;
        waitForFinishingThread.Start();

        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            cleaner.GetParentCheckBox().Checked = true;
        }

        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            optimizer.GetParentCheckBox().Checked = true;
        }

        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            spoofer.GetParentCheckBox().Checked = true;
        }
    }

    private void CheckBox_CheckedChanged5(object sender, EventArgs e)
    {
        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            optimizer.GetParentCheckBox().Checked = false;
        }
    }

    private void CheckBox_CheckedChanged4(object sender, EventArgs e)
    {
        foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
        {
            optimizer.GetParentCheckBox().Checked = true;
        }
    }

    private void CheckBox_CheckedChanged3(object sender, EventArgs e)
    {
        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            spoofer.GetParentCheckBox().Checked = false;
        }
    }

    private void CheckBox_CheckedChanged2(object sender, EventArgs e)
    {
        foreach (Spoofer spoofer in spooferManager.GetSpoofers())
        {
            spoofer.GetParentCheckBox().Checked = true;
        }
    }

    private void CheckBox_CheckedChanged1(object sender, EventArgs e)
    {
        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            cleaner.GetParentCheckBox().Checked = false;
        }
    }

    private void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        foreach (Cleaner cleaner in cleanerManager.GetCleaners())
        {
            cleaner.GetParentCheckBox().Checked = true;
        }
    }

    public void WaitForFinishing()
    {
        while (true)
        {
            Thread.Sleep(1000);

            this.Refresh();

            if (Utils.IsFinding())
            {
                this.Text = "ViperCleaner - Finding for files";
                bool isCompleted = true;

                foreach (Cleaner cleaner in this.cleanerManager.GetCleaners())
                {
                    if (cleaner.GetParentCheckBox().Checked)
                    {
                        if (!cleaner.IsFindingCompleted())
                        {
                            isCompleted = false;
                            break;
                        }
                    }
                }

                if (isCompleted)
                {
                    Utils.SetIsFinding(false);
                    gunaButton1.Text = "Find for files";
                    gunaButton2.Enabled = true;

                    foreach (Cleaner cleaner in cleanerManager.GetCleaners())
                    {
                        cleaner.GetParentFilesLabel().Text = cleaner.GetFoundFiles().Count.ToString();
                    }
                }
            }
            else if (Utils.IsCleaning())
            {
                this.Text = "ViperCleaner - Cleaning found files";
                bool isCompleted = true;

                foreach (Cleaner cleaner in this.cleanerManager.GetCleaners())
                {
                    if (cleaner.GetParentCheckBox().Checked)
                    {
                        if (!cleaner.IsCleaningCompleted())
                        {
                            isCompleted = false;
                            break;
                        }
                    }
                }

                if (isCompleted)
                {
                    Utils.SetIsCleaning(false);
                    gunaButton2.Text = "Clean found files";
                    gunaButton1.Enabled = true;

                    foreach (Cleaner cleaner in cleanerManager.GetCleaners())
                    {
                        cleaner.GetParentCleanedLabel().Text = cleaner.GetCleanedFiles().ToString();
                    }
                }
            }

            if (Utils.IsOptimizing())
            {
                this.Text = "ViperCleaner - Optimizing your machine";
                bool isCompleted = true;

                foreach (Optimizer optimizer in this.optimizerManager.GetOptimizers())
                {
                    if (optimizer.GetParentCheckBox().Checked)
                    {
                        if (!optimizer.IsOptimizingCompleted())
                        {
                            isCompleted = false;
                            break;
                        }
                    }
                }

                if (isCompleted)
                {
                    gunaButton3.Text = "Optimize now";
                    Utils.SetOptimizing(false);
                }
            }

            if (Utils.IsSpoofing())
            {
                this.Text = "ViperCleaner - Spoofing your machine hardware";
                bool isCompleted = true;

                foreach (Spoofer spoofer in this.spooferManager.GetSpoofers())
                {
                    if (spoofer.GetParentCheckBox().Checked)
                    {
                        if (!spoofer.IsSpoofingCompleted())
                        {
                            isCompleted = false;
                            break;
                        }
                    }
                }

                if (isCompleted)
                {
                    gunaButton4.Text = "Spoof now";
                    Utils.SetSpoofing(false);
                }
            }

            if (!Utils.IsSpoofing() && !Utils.IsOptimizing() && !Utils.IsCleaning() && !Utils.IsFinding())
            {
                this.Text = "ViperCleaner";
            }
        }
    }

    private void gunaButton1_Click(object sender, System.EventArgs e)
    {
        Thread thread = new Thread(StartFilesFinding);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    public void StartFilesFinding()
    {
        if (gunaButton1.Text == "Find for files")
        {
            this.Text = "ViperCleaner - Finding for files";
            gunaButton2.Enabled = false;
            gunaButton1.Text = "Stop finding files";
            Utils.SetIsFinding(true);

            foreach (Cleaner cleaner in this.cleanerManager.GetCleaners())
            {
                if (cleaner.GetParentCheckBox().Checked)
                {
                    cleaner.GetParentFilesLabel().Text = "0";

                    if (cleaner.IsCustomFind())
                    {
                        Thread thread = new Thread(() => cleaner.GetType().GetMethod("CustomFindForFiles").Invoke(cleaner, new object[] { }));
                        thread.Priority = ThreadPriority.Highest;
                        thread.Start();

                        if (!cleaner.IsCustomFindSostitutive())
                        {
                            Thread thread1 = new Thread(() => cleaner.FindForFiles());
                            thread1.Priority = ThreadPriority.Highest;
                            thread1.Start();
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(() => cleaner.FindForFiles());
                        thread.Priority = ThreadPriority.Highest;
                        thread.Start();
                    }
                }
            }
        }
        else
        {
            Utils.SetIsFinding(false);
            gunaButton1.Text = "Find for files";
            gunaButton2.Enabled = true;
        }
    }

    private void gunaButton2_Click(object sender, System.EventArgs e)
    {
        Thread thread = new Thread(StartFilesCleaning);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    public void StartFilesCleaning()
    {
        if (gunaButton2.Text == "Clean found files")
        {
            this.Text = "ViperCleaner - Cleaning found files";
            gunaButton1.Enabled = false;
            gunaButton2.Text = "Stop cleaning";
            Utils.SetIsCleaning(true);

            foreach (Cleaner cleaner in this.cleanerManager.GetCleaners())
            {
                if (cleaner.GetParentCheckBox().Checked)
                {
                    cleaner.GetParentCleanedLabel().Text = "0";

                    if (cleaner.IsCustomClean())
                    {
                        Thread thread = new Thread(() => cleaner.GetType().GetMethod("CustomCleanFiles").Invoke(cleaner, new object[] { }));
                        thread.Priority = ThreadPriority.Highest;
                        thread.Start();

                        if (!cleaner.IsCustomCleanSostitutive())
                        {
                            Thread thread1 = new Thread(() => cleaner.CleanFiles());
                            thread1.Priority = ThreadPriority.Highest;
                            thread1.Start();
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(() => cleaner.CleanFiles());
                        thread.Priority = ThreadPriority.Highest;
                        thread.Start();
                    }
                }
            }
        }
        else
        {
            Utils.SetIsCleaning(false);
            gunaButton2.Text = "Clean found files";
            gunaButton1.Enabled = true;
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }

    private void gunaButton3_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(StartOptimizing);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    public void StartOptimizing()
    {
        if (gunaButton3.Text == "Optimize now")
        {
            this.Text = "ViperCleaner - Optimizing your machine";
            gunaButton3.Text = "Stop optimizing";
            Utils.SetOptimizing(true);

            foreach (Optimizer optimizer in optimizerManager.GetOptimizers())
            {
                if (optimizer.GetParentCheckBox().Checked)
                {
                    Thread thread = new Thread(() => optimizerManager.ExecuteOptimizer(optimizer));
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                }
            }
        }
        else
        {
            gunaButton3.Text = "Optimize now";
            Utils.SetOptimizing(false);
        }
    }

    private void gunaButton4_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(StartSpoofing);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    public void StartSpoofing()
    {
        if (gunaButton4.Text == "Spoof now")
        {
            this.Text = "ViperCleaner - Spoofing your machine";
            gunaButton4.Text = "Stop spoofing";
            Utils.SetSpoofing(true);

            foreach (Spoofer spoofer in spooferManager.GetSpoofers())
            {
                if (spoofer.GetParentCheckBox().Checked)
                {
                    Thread thread = new Thread(() => spooferManager.ExecuteSpoofer(spoofer));
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                }
            }
        }
        else
        {
            gunaButton4.Text = "Spoof now";
            Utils.SetSpoofing(false);
        }
    }
}