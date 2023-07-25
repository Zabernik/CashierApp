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
        string language = "en";
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn(PINBox.Password);
        }
        /// <summary>Checking if PIN inserted in PINBox exist and opening mainMenu with logged user PIN</summary>
        /// <param name="PIN">The pin.</param>
        private void LogIn(string PIN)
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
