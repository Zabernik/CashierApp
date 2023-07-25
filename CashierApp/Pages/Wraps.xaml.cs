using System;
using CashierApp;
using CashierApp.Classes.Products.Wraps;
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
using CashierApp.Classes;
using CashierApp.Enums;

namespace CashierApp.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Wraps.xaml
    /// </summary>
    public partial class Wraps : Page
    {
        public Wraps()
        {
            InitializeComponent();
            SwitchLanguage(Login.language);
        }
        private void ButtonTortillaBacon_Click(object sender, RoutedEventArgs e)
        {
            TortillaBacon tortillaBacon = new TortillaBacon(FormsFood.Solo);
            tortillaBacon.CheckProductPrice();
            tortillaBacon.CheckProductIngredients();
            Order.AddProduct(tortillaBacon);
            ((MainWindow)Window.GetWindow(this)).CheckBill();

        }

        private void ButtonTortillaBaconSet_Click(object sender, RoutedEventArgs e)
        {
            TortillaBacon tortillaBacon = new TortillaBacon(FormsFood.Set);
            tortillaBacon.CheckProductPrice();
            tortillaBacon.CheckProductIngredients();
            Order.AddProduct(tortillaBacon);
            ((MainWindow)Window.GetWindow(this)).CheckBill();

        }
        private void ButtonTortillaBaconEnlargedSet_Click(object sender, RoutedEventArgs e)
        {
            TortillaBacon tortillaBacon = new TortillaBacon(FormsFood.EnlargedSet);
            tortillaBacon.CheckProductPrice();
            tortillaBacon.CheckProductIngredients();
            Order.AddProduct(tortillaBacon);
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
