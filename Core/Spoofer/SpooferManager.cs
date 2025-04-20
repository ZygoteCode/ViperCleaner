using System.Collections.Generic;
using Guna.UI.WinForms;
using System.Drawing;

public class SpooferManager
{
    private List<Spoofer> spoofers;
    private GunaVSeparator parentSeparator1;
    private GunaVSeparator parentSeparator2;

    public SpooferManager()
    {
        this.spoofers = new List<Spoofer>();
    }

    public List<Spoofer> GetSpoofers()
    {
        return this.spoofers;
    }

    public void AddSpoofer(Spoofer optimizer)
    {
        optimizer.GetType().GetMethod("Initialize").Invoke(optimizer, new object[] { });
        this.spoofers.Add(optimizer);

        if (this.spoofers.Count >= 22)
        {
            this.GetParentSeparator1().Size = new Size(this.GetParentSeparator1().Width, this.GetParentSeparator1().Height + 20);
            this.GetParentSeparator2().Size = new Size(this.GetParentSeparator2().Width, this.GetParentSeparator2().Height + 20);
        }
    }

    public void RemoveSpoofer(Spoofer spoofer)
    {
        this.spoofers.Remove(spoofer);
    }

    public void AddSpoofer(string name)
    {
        Spoofer spoofer = new Spoofer(name);
        AddSpoofer(spoofer);
    }

    public void RemoveSpoofer(string name)
    {
        foreach (Spoofer spoofer in spoofers)
        {
            if (spoofer.GetName().Equals(name))
            {
                this.spoofers.Remove(spoofer);
                break;
            }
        }
    }

    public Spoofer GetSpoofer(string name)
    {
        foreach (Spoofer spoofer in spoofers)
        {
            if (spoofer.GetName().Equals(name))
            {
                return spoofer;
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

    public GunaVSeparator GetParentSeparator1()
    {
        return this.parentSeparator1;
    }

    public GunaVSeparator GetParentSeparator2()
    {
        return this.parentSeparator2;
    }

    public void AddSpoofers()
    {
        this.AddSpoofer(new SpooferMACAddress());
    }

    public void ExecuteSpoofer(Spoofer spoofer)
    {
        spoofer.SetSpoofingCompleted(false);
        spoofer.GetParentStatusLabel().Text = "Working";
        spoofer.GetType().GetMethod("Execute").Invoke(spoofer, new object[] { });
        spoofer.SetSpoofingCompleted(true);
        spoofer.GetParentStatusLabel().Text = "Completed";
    }
}