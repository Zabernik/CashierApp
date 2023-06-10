using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes.Products.Burgers
{
    public class Cheesburger : BaseProduct, IDescription
    {
        public Cheesburger(FormsFood form) : base( "Cheesburger", false)
        {               
            if (form == FormsFood.EnlargedSet)
            {
                throw new ArgumentException("An Enlarged Set is not provided");
            }
            if (form == FormsFood.Set)
            {
                base.Price = 10.99m;
                base.ProductID = IdProducts.CheesburgerSet;
            }
            else
            {
                base.Price = 5.99m;
                base.ProductID = IdProducts.Cheesburger;
            }
        }
        public override string CheckIngredients()
        {
            return ("Bułka bez ziaren, musztarda, ketchup, 2szt pikli, ser, mięso wołowe");
        }
    }
}
