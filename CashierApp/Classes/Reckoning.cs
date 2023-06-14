using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes
{
    public class Reckoning
    {
        public decimal Value { get; set; }
        public string ValueText { get; set; }
        public string Currency { get; set; }

        public Reckoning(decimal value = 00.00m, string currency = "PLN", string valueText = "0")
        {
            Value = value;
            ValueText = valueText;
            Currency = currency;
        }
        public override string ToString() 
        { 
            return $"{ValueText} {Currency}";
        }
        public void ConvertToValue()
        {
            Value = Convert.ToDecimal(ValueText);
        }
    }
}
