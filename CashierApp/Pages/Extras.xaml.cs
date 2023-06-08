﻿using CashierApp.Classes.Products.Extras;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CashierApp.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Extras.xaml
    /// </summary>
    public partial class Extras : Page
    {
        public Extras()
        {
            InitializeComponent();
        }

        private void ButtonExtraChesse_Click(object sender, RoutedEventArgs e)
        {
            Cheese cheese = new Cheese();
            Order.AddExtra(cheese);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }

        private void ButtonExtraBacon_Click(object sender, RoutedEventArgs e)
        {
            Bacon bacon = new Bacon();
            Order.AddExtra(bacon);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
        }
    }
}