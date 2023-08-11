using CashierApp.Classes.DB;
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
using System.Windows.Shapes;

namespace CashierApp
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            SwitchLanguage(Login.language);
        }
        public bool Authorization { get; set; } = false;

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
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMethod();
        }
        /// <summary>That method is using to operate the number button etc.</summary>
        /// <param name="number">The number or value we want to be give to Reckoning propert ValueText</param>
        /// <param name="ignore">if set to <c>true</c> [ignore].</param>
        private void ButtonMethod(string number)
        {
            if (PINAuthorization.Password.Length < 6)
            {
                PINAuthorization.Password += number;
            }

        }
        /// <summary>That method clears reckoning and setting value to default/0</summary>
        private void ClearMethod()
        {
            PINAuthorization.Password = null;
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    var query = (from c in conn.Cashier
                                 where c.PIN == PINAuthorization.Password
                                 select new
                                 {
                                     c.Authorization
                                 }
                                 ).FirstOrDefault();
                    if (query != null)
                    {
                        Authorization = query.Authorization;
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Authorization = false;
            this.Close();
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
