﻿using CashierApp.Classes.Products.Salads;
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
            SwitchLanguage(Login.language);
        }
        private void ButtonPiccante_Click(object sender, RoutedEventArgs e)
        {
            Piccante piccante = new Piccante(FormsFood.Solo);
            piccante.CheckProductPrice();
            piccante.CheckProductIngredients();
            Order.AddProduct(piccante);
            ((MainWindow)Window.GetWindow(this)).CheckBill();
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
