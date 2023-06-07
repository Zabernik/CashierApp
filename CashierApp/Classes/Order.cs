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
        public decimal OrderValue { get; set; }
        public List<IdProducts> Products { get; set; }
        public List<decimal> PriceProducts { get; set; }
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
        public void AddProduct(BaseProduct obj)
        {
            Products.Add(obj.ProductID);
            PriceProducts.Add(obj.Price);
            OrderValue += obj.Price;
        }
        public void AddExtra(BaseExtra obj)
        {
            foreach (var product in Products)
            {
                bool CanBeExtra = ((int)product) < 400;
                if (CanBeExtra)
                {
                    PriceProducts.Add(obj.Price);
                    Products.Add(obj.ExtraID);
                    break;
                }
            }
        }
        public void DeleteProduct(int index)
        {
            Products.RemoveAt(index);
            PriceProducts.RemoveAt(index);
            OrderValue = PriceProducts.Sum();
        }
    }
}
