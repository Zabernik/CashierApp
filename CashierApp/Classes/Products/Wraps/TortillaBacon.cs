using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes.Products.Wraps
{
    public class TortillaBacon : BaseProduct, IDescription
    {
        public TortillaBacon(FormsFood form) : base("TortillaWithBacon", false)
        {
            if (form == FormsFood.EnlargedSet)
            {
                base.Price = 24.99m;
                base.ProductID = IdProducts.TortillaBaconEnlargedSet;
            }
            if (form == FormsFood.Set)
            {
                base.Price = 19.99m;
                base.ProductID = IdProducts.TortillaBaconSet;
            }
            if (form == FormsFood.Solo)
            {
                base.Price = 12m;
                base.ProductID = IdProducts.TortillaBacon;
            }
        }
        public override string CheckIngredients(string langCode)
        {
            switch (langCode)
            {
                case "pl":
                    return ("Tortilla 11', majonez, sałata, pomidor, bekon, kurczak");
                case "en":
                    return ("Tortilla 11', mayonnaise, lettuce, tomato, bacon and chicken");
                default:
                    return ("Tortilla 11', mayonnaise, lettuce, tomato, bacon and chicken");
            }
        }
    }
}
