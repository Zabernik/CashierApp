using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes.Products.Salads
{
    public class Piccante : BaseProduct, IDescription
    {
        public Piccante(FormsFood form) : base("Sałatka Piccante",false)
        {
            if (form == FormsFood.EnlargedSet)
            {
                throw new ArgumentException("An Enlarged Set is not provided");
            }
            if (form == FormsFood.Set)
            {
                base.Price = 19.99m;
                base.ProductID = IdProducts.PiccanteSet;
            }
            else
            {
                base.Price = 12m;
                base.ProductID = IdProducts.Piccante;
            }
        }
        public override string CheckIngredients(string langCode)
        {
            switch (langCode)
            {
                case "pl":
                    return ("Pierś z kurczaka, sałata, pomidor, ogórek, pestki dyni, ser żółty");
                case "en":
                    return ("Chicken breast, lettuce, tomato, cucumber, pumpkin seeds and cheese");
                default:
                    return ("Chicken breast, lettuce, tomato, cucumber, pumpkin seeds and cheese");
            }
        }
    }
}
