using CashierApp.Classes;
using CashierApp.Classes.DB;
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
    /// <summary> Flag for status</summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckLastTr();
            CheckBill();
            CashierName.Content = User.Name;
            SwitchLanguage(Login.language);
        }
        /// <summary>Create new first of the open app Order</summary>
        //Order order = new Order(1);
        /// <summary>Gets or sets a value indicating whether toggle button of CheckPrice
        /// is ON</summary>
        /// <value>
        ///   <c>true</c> if toggle button of CheckPrice is ON; otherwise, <c>false</c>.</value>
        public static bool CheckPrice { get; set; } = false;
        /// <summary>Gets or sets a value indicating whether toggle button of CheckIngredients is ON</summary>
        /// <value>
        ///   <c>true</c> if toggle button of CheckIngredients is ON; otherwise, <c>false</c>.</value>
        public static bool CheckIngredients { get; set; } = false;
        /// <summary>That method is using when last transaction is full payment. Create new Order, set value of labels to 0/null</summary>
        /// <param name="statusTr">if set to <c>true</c> that's mean last transaction was full paid</param>
        private void CheckLastTr()
        {
            try
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    var query = (from c in conn.Orders
                                 where c.IsFinished == false && c.CashierID == User.CashierId
                                 orderby c.Id
                                 select new
                                 {
                                     c.Id
                                 }
                                 ).LastOrDefault();
                    if (query != null)
                    {
                        Order order = new Order(query.Id);
                    }
                    else
                    {
                        Order order = new Order(1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error(CheckLastTr)");
                MessageBox.Show(ex.Message);
            }
        }
        public void newTr(bool statusTr)
        {
            if (statusTr == true)
            {
                Order order = new Order(1);
                Order.OrderValue = 0;
                Order.Products.Clear();
                Order.PriceProducts.Clear();
                CheckBill();
                Main.Content = new Welcome();
                ButtonChange(Visibility.Visible);
            }
        }
        /// <summary>This method clears all labels; all products in Order.Products is added to labels; for extras is given extra "- - -&gt;"</summary>
        public void CheckBill()
        {
            ListBoxOrder.Items.Clear();
            if (Order.Products is not null)
            {
                foreach (var product in Order.Products)
                {
                    if ((int)product > 500)
                    {
                        ListBoxOrder.Items.Add(new ListBoxItem { Content = $"- - - -> {product}", Foreground = Brushes.Red, Background = (Brush)(new BrushConverter().ConvertFrom("#aaaae4")) });
                    }
                    else
                    {
                        ListBoxOrder.Items.Add(new ListBoxItem { Content = product, Foreground = Brushes.White, Background = (Brush)(new BrushConverter().ConvertFrom("#aaaae4")) });
                    }
                }
                ListBoxValue.Items.Clear();
                foreach (var productPrice in Order.PriceProducts)
                {
                    ListBoxValue.Items.Add(new ListBoxItem { Content = productPrice, Foreground = Brushes.White, Background = (Brush)(new BrushConverter().ConvertFrom("#aaaae4")) });
                }
            }
            LabelValue.Content = $"{Order.OrderValue} PLN";
        }

        /// <summary>Method for return index of
        /// actual selected item</summary>
        /// <returns>int index of actual selected item</returns>
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
        /// <summary>This method is used for hide/show menu buttons</summary>
        /// <param name="status">The status of button we want to have</param>
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
        /// <summary>Switches the language of app;</summary>
        /// <param name="langCode">The language code.</param>
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
        /// <summary>Deleting the last open order and close app, and open new login window.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

            void logOut()
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    var lastOrder = new Orders { Id = Order.Id };
                    conn.Orders.Attach(lastOrder);
                    conn.Orders.Remove(lastOrder);
                    conn.SaveChanges();
                }
                Login login = new Login();
                login.Show();
                this.Close();
            }

            if (Order.OrderValue == 0)
            {
                logOut();
            }
            else
            {
                if (Login.language == "pl")
                {
                    if (MessageBox.Show("Czy chcesz anulować tą transakcje?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (User.Authorization(User.CashierId) == false)
                        {
                            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                            authorizationWindow.ShowDialog();
                            if (authorizationWindow.Authorization == true)
                            {
                                logOut();
                            }
                            else
                            {
                                MessageBox.Show("Błąd autoryzacji");
                            }
                        }
                        else
                        {
                            logOut();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to cancel this transaction?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (User.Authorization(User.CashierId) == false)
                        {
                            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                            authorizationWindow.ShowDialog();
                            if (authorizationWindow.Authorization == true)
                            {
                                logOut();
                            }
                            else
                            {
                                MessageBox.Show("Authorization Error");
                            }
                        }
                        else 
                        { 
                            logOut(); 
                        }
                    }
                }              
            }
        }
        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
