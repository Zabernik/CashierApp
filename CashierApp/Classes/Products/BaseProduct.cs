using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes.Products
{
    public class BaseProduct : IEquatable<BaseProduct>
    {
        public IdProducts ProductID { get; set; }
        protected string ProductName { get; set; }
        protected bool IsUpsell { get; set; }
        public decimal Price { get; set; }

        public BaseProduct(IdProducts productID, string productName, bool isUpsell, decimal price) 
        { 
            ProductID = productID;
            ProductName = productName;
            IsUpsell = isUpsell;
            Price = price;
        }
        public BaseProduct(string productName, bool isUpsell)
        {
            ProductName = productName;
            IsUpsell = isUpsell;
        }

        public override string ToString()
        {
            return $"Dane produktu {ProductName} to: \n" +
                   $"ProductID - {ProductID} \n" +
                   $"IsUpsell - {IsUpsell} \n" +
                   $"Cena - {Price} \n";
        }

        public bool Equals(BaseProduct other)
        {
            if (this.Price == other.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(BaseProduct obj1, BaseProduct obj2)
        {
            if (obj1.Price == obj2.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(BaseProduct obj1, BaseProduct obj2)
        {
            if (obj1.Price != obj2.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CheckProductPrice()
        {
            if (MainWindow.CheckPrice is true)
            {
                MessageBox.Show($"{this.ProductName} kosztuje {this.Price} PLN");
            }
        }
        public void CheckProductIngredients()
        {
            if (MainWindow.CheckIngredients is true)
            {
                MessageBox.Show($"{this.ProductName} zawiera: \n" +
                    $"{this.CheckIngredients()}");
            }
        }
        public virtual string CheckIngredients()
        {
            return "Brak wprowadzonego składu";
        }
    }
}
