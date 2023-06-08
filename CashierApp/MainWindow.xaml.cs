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
        public static bool CheckPrice { get; set; } = false;
        public void CheckBill()
        {
            ListBoxOrder.Items.Clear();
            foreach (var product in Order.Products)
            {
                if ((int)product > 500)
                {
                    ListBoxOrder.Items.Add(new ListBoxItem { Content = $"- - - -> {product}", Foreground = Brushes.Green });
                    //new SolidColorBrush(Colors.Aqua);
                }
                else
                {
                    ListBoxOrder.Items.Add($"{product}");
                }
            }
            ListBoxValue.Items.Clear();
            foreach (var productPrice in Order.PriceProducts)
            {
                ListBoxValue.Items.Add($"{productPrice}");
            }
            LabelValue.Content = $"{Order.OrderValue} PLN";
        }
        public int SelectIndex()
        {
            return ListBoxOrder.SelectedIndex;
        }
        private void VoidButton_Click(object sender, RoutedEventArgs e)
        {
            Order.DeleteProduct(SelectIndex());
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

        private void ButtonCheckPrice_Checked(object sender, RoutedEventArgs e)
        {
            CheckPrice = true;
        }

        private void ButtonCheckPrice_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckPrice = false;
        }
    }
}
