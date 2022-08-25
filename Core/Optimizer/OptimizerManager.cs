using System.Collections.Generic;
using Guna.UI.WinForms;
using System.Drawing;

public class OptimizerManager
{
    private List<Optimizer> optimizers;
    private GunaVSeparator parentSeparator1;
    private GunaVSeparator parentSeparator2;

    public OptimizerManager()
    {
        this.optimizers = new List<Optimizer>();
    }

    public List<Optimizer> GetOptimizers()
    {
        return this.optimizers;
    }

    public void AddOptimizer(Optimizer optimizer)
    {
        optimizer.GetType().GetMethod("Initialize").Invoke(optimizer, new object[] { });
        this.optimizers.Add(optimizer);

        if (this.optimizers.Count >= 22)
        {
            this.GetParentSeparator1().Size = new Size(this.GetParentSeparator1().Width, this.GetParentSeparator1().Height + 20);
            this.GetParentSeparator2().Size = new Size(this.GetParentSeparator2().Width, this.GetParentSeparator2().Height + 20);
        }
    }

    public void RemoveOptimizer(Optimizer optimizer)
    {
        this.optimizers.Remove(optimizer);
    }

    public void AddOptimizer(string name)
    {
        Optimizer optimizer = new Optimizer(name);
        AddOptimizer(optimizer);
    }

    public void RemoveSpoofer(string name)
    {
        foreach (Optimizer optimizer in optimizers)
        {
            if (optimizer.GetName().Equals(name))
            {
                this.optimizers.Remove(optimizer);
                break;
            }
        }
    }

    public Optimizer GetOptimizer(string name)
    {
        foreach (Optimizer optimizer in optimizers)
        {
            if (optimizer.GetName().Equals(name))
            {
                return optimizer;
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

    public void AddOptimizers()
    {
        this.AddOptimizer(new OptimizerTCPOptimizations());
    }

    public void ExecuteOptimizer(Optimizer optimizer)
    {
        optimizer.SetOptimizingCompleted(false);
        optimizer.GetParentStatusLabel().Text = "Working";
        optimizer.GetType().GetMethod("Execute").Invoke(optimizer, new object[] { });
        optimizer.SetOptimizingCompleted(true);
        optimizer.GetParentStatusLabel().Text = "Completed";
    }
}