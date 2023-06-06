using CashierApp.Classes;
using CashierApp.Classes.Products;
using CashierApp.Classes.Products.Burgers;
using CashierApp.Classes.Products.Extras;
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
        }
        Order order = new Order(1);
        private void ButtonCheesburger_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Solo);
            cheesburger.AddToBill(order);
            order.AddProduct(cheesburger);
            CheckBill();
        }
        private void ButtonCheesburgerSet_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Set);
            cheesburger.AddToBill(order);
            order.AddProduct(cheesburger);
            CheckBill();
        }
        private void ButtonExtraChesse_Click(object sender, RoutedEventArgs e)
        {
            Cheese cheese = new Cheese();
            cheese.AddToBill(order);
            order.AddExtra(cheese);
            CheckBill();
        }
        private void ButtonExtraBacon_Click(object sender, RoutedEventArgs e)
        {
            Bacon bacon = new Bacon();
            bacon.AddToBill(order);
            order.AddExtra(bacon);
            CheckBill();
        }
        public void CheckBill()
        {
            ListBoxOrder.Items.Clear();
            foreach (var product in order.Products)
            {
                ListBoxOrder.Items.Add(product);
            }
            if (ListBoxOrder.Items.Count == 0)
            {
                VoidButton.IsEnabled = false;
            }
            else
            {
                VoidButton.IsEnabled = true;
            }
            CheckValue();
        }
        public void CheckValue()
        {
            LabelValue.Content = order.OrderValue.ToString();
        }

        private void VoidButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                int indexPriceProduct = ListBoxOrder.SelectedIndex;
                string product = ListBoxOrder.SelectedItem.ToString();
                MessageBox.Show(product);
                order.DeleteProduct(product,indexPriceProduct);
            }
            catch (Exception x)
            {
                MessageBox.Show("Nie zaznaczono pozycji do usunięcia");
            }
            CheckBill();
        }
    }
}
