using MoonSharp.Interpreter;
using System;

namespace XamlBrewer.UWP.MoonSharpSample.Models
{
    /// <summary>
    /// A sample C# class that is shared with some of the Lua scripts.
    /// </summary>
    [MoonSharpUserData]
    public class BusinessObject
    {
        private double vatRate = 20.0;

        public event EventHandler SomethingHappened;

        public void RaiseTheEvent()
        {
            if (SomethingHappened != null)
                SomethingHappened(this, EventArgs.Empty);
        }

        public double VatRate
        {
            get { return vatRate; }
            set { vatRate = value; }
        }
        
        public Double CalculateVAT(double amount)
        {
            return amount * vatRate / 100;
        }
    }
}
