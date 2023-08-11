using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CashierApp.Classes.DB;
using Microsoft.EntityFrameworkCore;

namespace CashierApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //DatabaseFacade databaseFacade = new DatabaseFacade(new DataBaseContext());
            //databaseFacade.EnsureCreated();
            InsertDataToDB();
        }
        /// <summary>Inserts the data to database about admin and cashier.</summary>
        private void InsertDataToDB()
        {
            using (DataBaseContext conn = new DataBaseContext())
            {
                try
                {
                    if (!conn.Cashier.Any(adminExist => adminExist.CashierId == "0000"))
                    {
                        Cashier admin = new Cashier { Name = "Admin", Surname = "Admin", CashierId = "0000", PIN = "000000", Authorization = true };
                        conn.Add<Cashier>(admin);
                        conn.SaveChanges();
                    }
                    if (!conn.Cashier.Any(cashier01Exist => cashier01Exist.CashierId == "0001"))
                    {
                        Cashier cashier01 = new Cashier { Name = "Jan", Surname = "Kowalski", CashierId = "0001", PIN = "111111", Authorization = false };
                        conn.Add<Cashier>(cashier01);
                        conn.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect with database, network error");
                }
            }
        }
    }
}
