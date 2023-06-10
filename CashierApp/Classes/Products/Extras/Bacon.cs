using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products.Extras
{
    public class Bacon : BaseExtra, IDescription
    {
        public Bacon() : base("Bekon", 1.00m, IdProducts.Bacon)
        { 

        }
        public override string CheckIngredients()
        {
            return "Dwa pół plastry bekonu";
        }
    }
}
