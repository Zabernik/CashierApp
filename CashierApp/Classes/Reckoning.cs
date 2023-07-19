using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public bool SettleBill(string payment, decimal orderValue)
        {
            if (payment == "cash")
            {
                if (this.Value < orderValue || orderValue == 0)
                {
                    return false;
                }
                return true;
            }
            if (payment == "card")
            {
                return true;
            }
            if (payment == "fullCash")
            {
                if (orderValue == 0)
                {
                    return false;
                }
                return true;
            }
            if (payment != "fullCash" && payment != "card" && payment != "cash")
            {
                throw new Exception("NoSuchFormOfPayment");
            }
            return false;
        }
        public void PrintBill()
        {
            MessageBox.Show($"Print Bill \n" +
                            $"Cashier - \n" +
                            $"Value - \n" +
                            $"Currency - ");
        }
    }
}
