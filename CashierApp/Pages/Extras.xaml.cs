using CashierApp.Classes.Products.Extras;
using CashierApp.Classes;
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
    /// Logika interakcji dla klasy Extras.xaml
    /// </summary>
    public partial class Extras : Page
    {
        public Extras()
        {
            InitializeComponent();
            SwitchLanguage(Login.language);
        }

        private void ButtonExtraChesse_Click(object sender, RoutedEventArgs e)
        {
            int index = ((MainWindow)Window.GetWindow(this)).SelectIndex();

            Cheese cheese = new Cheese();
            cheese.CheckProductPrice();
            cheese.CheckProductIngredients();
            Order.AddExtra(cheese,index);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }

        private void ButtonExtraBacon_Click(object sender, RoutedEventArgs e)
        {
            int index = ((MainWindow)Window.GetWindow(this)).SelectIndex();

            Bacon bacon = new Bacon();
            bacon.CheckProductPrice();
            bacon.CheckProductIngredients();
            Order.AddExtra(bacon,index);
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
