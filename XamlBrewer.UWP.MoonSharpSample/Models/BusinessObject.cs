using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBrewer.UWP.MoonSharpSample.Models
{
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
