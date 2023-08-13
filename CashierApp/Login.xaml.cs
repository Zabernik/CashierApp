using CashierApp.Classes.DB;
using CashierApp.Classes;
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
using System.Windows.Shapes;

namespace CashierApp
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            SwitchLanguage(language);
        }
        public static string language = "en";
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn(PINBox.Password);
        }
        /// <summary>Checking if PIN inserted in PINBox exist and opening mainMenu with logged user PIN</summary>
        /// <param name="PIN">The pin.</param>
        private void LogIn(string PIN)
        {
            try
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    if (conn.Cashier.Any(cashierExist => cashierExist.PIN == PIN))
                    {
                        DownloadDataCashier(PIN);
                        MainWindow main = new MainWindow();
                        main.Show();
                        Application.Current.MainWindow = main;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nie poprawny PIN kasjera");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error");
            }
        }
        /// <summary>Downloads the data about cashier.</summary>
        /// <param name="PIN">The pin logged cashier</param>
        private void DownloadDataCashier(string PIN)
        {
            User user = new User();
            User.Name = user.GetName(PIN);
            User.CashierId = user.GetID(PIN);
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            if (language == "en")
            {
                language = "pl";
            }
            else
            {
                language = "en";
            }
            SwitchLanguage(language);
        }

        public void SwitchLanguage(string langCode)
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
        private void ClearMethod()
        {
            PINBox.Password = null;
        }
        private void ButtonMethod(string number)
        {
            if (PINBox.Password.Length < 6)
            {
                PINBox.Password += number;
                if (PINBox.Password.Length == 6)
                {
                    LogIn(PINBox.Password);
                }
            }

        }
    }
}
