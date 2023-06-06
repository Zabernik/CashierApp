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
    public class ChickenBurger : BaseProduct, IDescription
    {
        public ChickenBurger(FormsFood form) : base("ChickenBurger",false)
        {
            if (form == FormsFood.EnlargedSet)
            {
                base.Price = 20.99m;
                base.ProductID = IdProducts.ChickenBurgerEnlargedSet;
            }
            if (form == FormsFood.Set)
            {
                base.Price = 16.99m;
                base.ProductID = IdProducts.ChickenBurgerSet;
            }
            else
            {
                base.Price = 9.99m;
                base.ProductID = IdProducts.ChickenBurger;
            }
        }

        public void CheckPrice()
        {
            MessageBox.Show(base.Price.ToString());
        }

        public void CheckIngredients()
        {
            MessageBox.Show("Bułka z ziarnami, majonez, sałata, mięso z kurczaka");
        }


    }
}
