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
            order.AddProduct(cheesburger);
            CheckBill();
        }
        private void ButtonCheesburgerSet_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger cheesburger = new Cheesburger(FormsFood.Set);
            order.AddProduct(cheesburger);
            CheckBill();
        }
        private void ButtonExtraChesse_Click(object sender, RoutedEventArgs e)
        {
            Cheese cheese = new Cheese();
            order.AddExtra(cheese);
            CheckBill();
        }
        private void ButtonExtraBacon_Click(object sender, RoutedEventArgs e)
        {
            Bacon bacon = new Bacon();
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
            CheckValue();
        }
        public void CheckValue()
        {
            LabelValue.Content = order.OrderValue.ToString();
        }

        private void VoidButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBoxOrder.SelectedIndex;
            order.DeleteProduct(index);
            CheckBill();
        }
    }
}
