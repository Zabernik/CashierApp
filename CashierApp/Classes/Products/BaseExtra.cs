using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products
{
    public class BaseExtra
    {
        public IdProducts ExtraID { get; set; }
        protected string Name { get; set; }
        public decimal Price { get; set; }
        protected bool IsUpsell = true;

        public BaseExtra(string name, decimal price, IdProducts extraID) 
        { 
            ExtraID = extraID;
            Name = name;
            Price = price;
        }
        public void AddToBill(Order obj)
        {
            obj.OrderValue += this.Price;
        }
    }
}
