using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products
{
    public class BaseExtra : BaseProduct
    {
        public IdProducts ExtraID { get; set; }
        protected string Name { get; set; }
        public decimal Price { get; set; }
        protected bool IsUpsell = true;

        public BaseExtra(string name, decimal price, IdProducts extraID) : base(extraID,name,true,price) 
        { 
            ExtraID = extraID;
            Name = name;
            Price = price;
        }
    }
}
