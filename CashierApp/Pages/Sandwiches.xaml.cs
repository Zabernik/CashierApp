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
        }
        private void ButtonCheesburger_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Solo);
            cheesburger.CheckProductPrice();
            Order.AddProduct(cheesburger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();

        }
        private void ButtonCheesburgerSet_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Set);
            cheesburger.CheckProductPrice();
            Order.AddProduct(cheesburger);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }
    }
}
