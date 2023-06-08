using CashierApp.Classes.Products;
using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CashierApp.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public static decimal OrderValue { get; set; }
        public static List<IdProducts> Products { get; set; }
        public static List<decimal> PriceProducts { get; set; }
        public Order(int id)
        {
            Products = new List<IdProducts>();
            PriceProducts = new List<decimal>();
            Id = id;
        }

        public override string ToString()
        {
            return $"{OrderValue} PLN";
        }
        public static void AddProduct(BaseProduct obj)
        {
            if (MainWindow.CheckPrice is false)
            {
                Products.Add(obj.ProductID);
                PriceProducts.Add(obj.Price);
                OrderValue += obj.Price;
            }
        }
        public static void AddExtra(BaseExtra obj, int index)
        {
            if (MainWindow.CheckPrice is false)
            {
                try
                {
                    bool CanBeExtra = (int)Products[index] < 400;
                    if (CanBeExtra is true)
                    {
                        PriceProducts.Insert(index + 1, obj.Price);
                        Products.Insert(index + 1, obj.ExtraID);
                        OrderValue = PriceProducts.Sum();
                    }
                    else
                    {
                        MessageBox.Show("Nie można dodać dodatku");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie można dodać dodatku");
                }
            }
        }
        public static void DeleteProduct(int index)
        {
            try
            {
                Products.RemoveAt(index);
                PriceProducts.RemoveAt(index);
                OrderValue = PriceProducts.Sum();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Najpierw zaznacz produkt do usunięcia");
            }        
        }
    }
}
