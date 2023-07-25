using CashierApp.Classes.Products.Burgers;
using CashierApp.Classes;
using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CashierApp.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Sandwiches.xaml
    /// </summary>
    public partial class Sandwiches : Page
    {
        public Sandwiches()
        {
            InitializeComponent();
            SwitchLanguage(Login.language);
        }
        private void ButtonCheesburger_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Solo);
            cheesburger.CheckProductPrice();
            cheesburger.CheckProductIngredients();
            Order.AddProduct(cheesburger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();

        }
        private void ButtonCheesburgerSet_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Set);
            cheesburger.CheckProductPrice();
            cheesburger.CheckProductIngredients();
            Order.AddProduct(cheesburger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }

        private void ButtonChickenBurger_Click(object sender, RoutedEventArgs e)
        {
            ChickenBurger chickenBurger = new ChickenBurger(FormsFood.Solo);
            chickenBurger.CheckProductPrice();
            chickenBurger.CheckProductIngredients();
            Order.AddProduct(chickenBurger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }

        private void ButtonChickenBurgerEnlargedSet_Click(object sender, RoutedEventArgs e)
        {
            ChickenBurger chickenBurger = new ChickenBurger(FormsFood.EnlargedSet);
            chickenBurger.CheckProductPrice();
            chickenBurger.CheckProductIngredients();
            Order.AddProduct(chickenBurger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }

        private void ButtonChickenBurgerSet_Click(object sender, RoutedEventArgs e)
        {
            ChickenBurger chickenBurger = new ChickenBurger(FormsFood.Set);
            chickenBurger.CheckProductPrice();
            chickenBurger.CheckProductIngredients();
            Order.AddProduct(chickenBurger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }
        private void SwitchLanguage(string langCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            if (langCode == "pl")
            {
                dictionary.Source = new Uri("../Language\\StringRecources.pl.xaml", UriKind.Relative);
            }
            else
            {
                dictionary.Source = new Uri("../Language\\StringRecources.en.xaml", UriKind.Relative);
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
