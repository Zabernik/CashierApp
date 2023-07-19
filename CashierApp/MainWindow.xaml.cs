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
        public static bool CheckIngredients { get; set; } = false;
        public void CheckBill()
        {
            ListBoxOrder.Items.Clear();
            foreach (var product in Order.Products)
            {
                if ((int)product > 500)
                {
                    ListBoxOrder.Items.Add(new ListBoxItem { Content = $"- - - -> {product}", Foreground = Brushes.Green });
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
            if (CheckIngredients is true)
            {
                CheckIngredients = false;
                ButtonCheckIngredients.IsChecked = false;
            }
        }

        private void ButtonCheckPrice_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckPrice = false;
        }

        private void ButtonCheckIngredients_Checked(object sender, RoutedEventArgs e)
        {
            CheckIngredients = true;
            if (CheckPrice is true)
            {
                CheckPrice = false;
                ButtonCheckPrice.IsChecked = false;
            }
        }

        private void ButtonCheckIngredients_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckIngredients = false;
        }

        private void SettleButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettlePage();
            ButtonChange(Visibility.Hidden);
        }

        private void ButtonDeserts_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Deserts();
        }

        private void ButtonHotDrinks_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Drinks();
        }

        private void ButtonDrinks_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HotDrinks();
        }
        private void ButtonChange(Visibility status)
        {
            ButtonCheckIngredients.Visibility = status;
            ButtonCheckPrice.Visibility = status;
            ButtonSalads.Visibility = status;
            ButtonSandwich.Visibility = status;
            ButtonWraps.Visibility = status;
            ButtonExtras.Visibility = status;
            ButtonHotDrinks.Visibility = status;
            ButtonDrinks.Visibility = status;
            ButtonDeserts.Visibility = status;
            SettleButton.Visibility = status;
            if (status is Visibility.Hidden)
            {
                ExitButton.Visibility = Visibility.Visible;
            }
            else { ExitButton.Visibility = Visibility.Hidden; }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonChange(Visibility.Visible);
            Main.Content = new Welcome();
        }
    }
}
