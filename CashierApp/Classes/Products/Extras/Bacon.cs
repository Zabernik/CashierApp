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
        public override string CheckIngredients(string langCode)
        {
            switch (langCode)
            {
                case "pl":
                    return ("Dwa pół plastry bekonu");
                case "en":
                    return ("Two half slices of bacon");
                default:
                    return ("Two half slices of bacon");
            }
        }
    }
}
