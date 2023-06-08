using CashierApp.Classes;
using CashierApp.Classes.Products;
using CashierApp.Classes.Products.Burgers;
using CashierApp.Classes.Products.Extras;
using CashierApp.Enums;
using CashierApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace CashierApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckBill();
        }
        Order order = new Order(1);
        public void CheckBill()
        {
            ListBoxOrder.Items.Clear();
            foreach (var product in Order.Products)
            {
                ListBoxOrder.Items.Add(product);
            }
            LabelValue.Content = $"{Order.OrderValue.ToString()} PLN";
        }

        private void VoidButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBoxOrder.SelectedIndex;
            Order.DeleteProduct(index);
            CheckBill();
        }

        private void ButtonSandwich_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Sandwiches();
        }

        private void ButtonWraps_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Wraps();
        }

        private void ButtonSalads_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Salads();
        }

        private void ButtonExtras_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Extras();
        }
    }
}
