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
        public decimal OrderValue
        {
            get
            {
                return OrderValue;
            }
            set
            {
                foreach (var price in PriceProducts)
                {
                    OrderValue += price;
                }
            }
        }
        public List<IdProducts> Products { get; set; }
        public List<decimal> PriceProducts { get; set; }
        public Order(int id)
        {
            Products = new List<IdProducts>();
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
        }
        public void AddExtra(BaseExtra obj)
        {
            bool CanBeExtra = false;
            foreach (var product in Products)
            {
                CanBeExtra = ((int)product) < 1000;
                if (CanBeExtra)
                {
                    goto B;                   
                }
            }

            B:
            if (CanBeExtra is true)
            {
                PriceProducts.Add(obj.Price);
                Products.Add(obj.ExtraID);
            }
            else
            {
                MessageBox.Show("Nie można dodawać dodatków bez kanapek");
            }
        }
        public void DeleteProduct(string product,int indexPriceProduct)
        {
            var productID = (IdProducts)Enum.Parse(typeof(IdProducts), product);
            Products.Remove(productID);
            PriceProducts.RemoveAt(indexPriceProduct);
        }
    }
}
