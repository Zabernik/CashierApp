using CashierApp.Classes.Products;
using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public decimal OrderValue { get; set; }
        public List<IdProducts> Products { get; set; }
        public Order(int id)
        {
            Products = new List<IdProducts>();
            Id = id;
        }

        public override string ToString()
        {
            return $"{OrderValue}";
        }
        public void AddProduct(BaseProduct obj)
        {
            Products.Add(obj.ProductID);
        }
        public void AddExtra(BaseExtra obj)
        {
            if (Products. )
            {
                Products.Add(obj.ExtraID);
            }
            else
            {
                MessageBox.Show("Nie można dodawać dodatków bez kanapek");
            }
        }
        public void DeleteProduct()
        {

        }
    }
}
