using CashierApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy SettlePage.xaml
    /// </summary>
    public partial class SettlePage : Page
    {
        Reckoning reck = new Reckoning();
        public SettlePage()
        {
            InitializeComponent();
            labelValue.Content = reck.ToString();
        }

        private void Button1Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("1");
        }

        private void Button2Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("2");
        }

        private void Button3Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("3");
        }

        private void Button4Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("4");
        }

        private void Button5Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("5");
        }

        private void Button6Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("6");
        }

        private void Button7Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("7");
        }

        private void Button8Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("8");
        }

        private void Button9Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("9");
        }

        private void Button0Number_Click(object sender, RoutedEventArgs e)
        {
            ButtonMethod("0");
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            //reck.ValueText += ",";
            //reck.ConvertToValue();
            //labelValue.Content = reck.ToString();
            ButtonMethod(",",true);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            reck.Value = default;
            reck.ValueText = "0";
            labelValue.Content = reck.ToString();
        }
        private void ButtonMethod(string number, bool ignore = false)
        {
            string test = reck.ValueText;
            test += number;
            Regex regex = new Regex(@"^\d{0,6},{0,1}\d{0,2}$");
            if (!regex.IsMatch(test))
            {
                MessageBox.Show("Błąd");
            }
            else
            {
                if (ignore is false)
                {
                    if (reck.ValueText == "0")
                    {
                        reck.ValueText = "";
                    }
                }
                reck.ValueText += number;
                reck.ConvertToValue();
                labelValue.Content = reck.ToString();
            }
        }
    }
}
