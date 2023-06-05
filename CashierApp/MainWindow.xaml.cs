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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cheesburger chees1 = new Cheesburger(FormsFood.Solo);
            Cheesburger chees2 = new Cheesburger(FormsFood.Solo);
            Cheesburger chees3 = new Cheesburger(FormsFood.Set);

            Bacon bacon = new Bacon();

            chees1.AddExtra(bacon);
        }
    }
}
