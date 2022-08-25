using ns1;
using MetroSuite;

public class Spoofer
{
    private string name;
    private string category;
    private string status;
    private SiticoneCheckBox parentCheckBox;
    private MetroLabel parentNameLabel;
    private MetroLabel parentCategoryLabel;
    private MetroLabel parentStatusLabel;
    private bool spoofCompleted;

    public Spoofer(string name, string category = "Network", string status = "Ready")
    {
        this.name = name;
        this.category = category;
        this.status = status;
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

    public string GetCategory()
    {
        return this.category;
    }

    public void SetCategory(string category)
    {
        this.category = category;
        this.GetParentCategoryLabel().Text = category;
    }

    public SiticoneCheckBox GetParentCheckBox()
    {
        return this.parentCheckBox;
    }

    public void SetParentCheckBox(SiticoneCheckBox checkBox)
    {
        this.parentCheckBox = checkBox;
    }

    public MetroLabel GetParentNameLabel()
    {
        return this.parentNameLabel;
    }

    public void SetParentNameLabel(MetroLabel label)
    {
        this.parentNameLabel = label;
    }

    public MetroLabel GetParentCategoryLabel()
    {
        return this.parentCategoryLabel;
    }

    public void SetParentCategoryLabel(MetroLabel label)
    {
        this.parentCategoryLabel = label;
    }

    public MetroLabel GetParentStatusLabel()
    {
        return this.parentStatusLabel;
    }

    public void SetParentStatusLabel(MetroLabel label)
    {
        this.parentStatusLabel = label;
    }

    public string GetStatus()
    {
        return this.status;
    }

    public void SetStatus(string status)
    {
        this.status = status;
        this.GetParentStatusLabel().Text = status;
    }

    public bool IsSpoofingCompleted()
    {
        return this.spoofCompleted;
    }

    public void SetSpoofingCompleted(bool spoofCompleted)
    {
        this.spoofCompleted = spoofCompleted;
    }
}