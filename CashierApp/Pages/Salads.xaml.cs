using CashierApp.Classes.Products.Salads;
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
    /// Logika interakcji dla klasy Salads.xaml
    /// </summary>
    public partial class Salads : Page
    {
        public Salads()
        {
            InitializeComponent();
        }
        private void ButtonPiccante_Click(object sender, RoutedEventArgs e)
        {
            Piccante piccante = new Piccante(FormsFood.Solo);
            piccante.CheckProductPrice();
            Order.AddProduct(piccante);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }
    }
}
