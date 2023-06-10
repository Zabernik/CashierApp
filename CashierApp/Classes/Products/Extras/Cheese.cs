using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products.Extras
{
    public class Cheese : BaseExtra, IDescription
    {
        public Cheese() : base("Ser", 1.00m, IdProducts.Cheese)
        {
        }
        public override string CheckIngredients()
        {
            return "Plaster topionego sera";
        }
    }
}
