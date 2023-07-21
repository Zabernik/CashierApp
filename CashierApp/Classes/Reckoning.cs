using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes
{
    /// <summary>Class for reckoning transaction</summary>
    public class Reckoning
    {
        /// <summary>Gets or sets the numerical value of reckoning</summary>
        /// <value>Decimal of reckoning</value>
        public decimal Value { get; set; }
        /// <summary>Gets or sets the numerical value of reckoning</summary>
        /// <value>String get's by decimal Value</value>
        public string ValueText { get; set; }
        /// <summary>Gets or sets the currency.</summary>
        /// <value>The currency of value</value>
        public string Currency { get; set; }
        /// <summary>Gets or sets a value indicating whether transaction is done</summary>
        /// <value>
        ///   <c>False </c>if transaction is on order and payment doesn't end ; otherwise, <c>true</c>.</value>
        public static bool StatusTr { get; set; } = false;

        /// <summary>Initializes a new instance of the <see cref="Reckoning" /> class.</summary>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="valueText">The value text.</param>
        public Reckoning(decimal value = 00.00m, string currency = "PLN", string valueText = "0")
        {
            Value = value;
            ValueText = valueText;
            Currency = currency;
        }
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() 
        { 
            return $"{ValueText} {Currency}";
        }
        /// <summary>Converts string ValueText to decimal Value</summary>
        public void ConvertToValue()
        {
            Value = Convert.ToDecimal(ValueText);
        }
        /// <summary>Method to settles the bill; there are all form of payment you can use</summary>
        /// <param name="payment">Form of payment; for now only 3 types</param>
        /// <param name="orderValue">The order value.</param>
        /// <returns>Return true if that payment exist AND condition is fulfilled<br /></returns>
        /// <exception cref="System.Exception">NoSuchFormOfPayment</exception>
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
        /// <summary>Method for future send data to print a bill and send data to db</summary>
        public void PrintBill()
        {
            MessageBox.Show($"Print Bill \n" +
                            $"Cashier - \n" +
                            $"Value - \n" +
                            $"Currency - ");
            endTr();
        }
        /// <summary>When transaction is done, flag StatusTr is set to true and start running other method newTr from MainWindow</summary>
        private void endTr()
        {
            StatusTr = true;
            ((MainWindow)Application.Current.MainWindow).newTr(Reckoning.StatusTr);
        }
    }
}
