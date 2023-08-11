using CashierApp.Classes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes
{
    /// <summary>Class for specifie a cashier like ID/Name/Surname employee</summary>
    public class User
    {
        public static string Name { get; set; }
        public static string CashierId { get; set; }

        /// <summary>Gets the full name from DB by PIN.</summary>
        /// <param name="PIN">The pin.</param>
        /// <returns>Name + Surname Cashier</returns>
        public string GetName(string PIN)
        {
            string Name = default;
            try
            {
                using (DataBaseContext ctx = new DataBaseContext())
                {
                    var query = (from c in ctx.Cashier
                                 where c.PIN == PIN
                                 select new
                                 {
                                     c.Name,
                                     c.Surname,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        Name = query.Name + " " + query.Surname;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error");
            }
            return Name;
        }
        /// <summary>Gets the identifier from DB by PIN.</summary>
        /// <param name="PIN">The pin.</param>
        /// <returns>ID Cashier</returns>
        public string GetID(string PIN)
        {
            string Data = default;
            try
            {
                using (DataBaseContext ctx = new DataBaseContext())
                {
                    var query = (from c in ctx.Cashier
                                 where c.PIN == PIN
                                 select new
                                 {
                                     c.CashierId
                                 }
                                 ).FirstOrDefault();
                    if (query != null)
                    {
                        Data = query.CashierId;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error");
            }                    
            return Data;
        }
        public static bool Authorization(string cashierID)
        {
            bool auth = false;
            try
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    var query = (from c in conn.Cashier
                                 where c.CashierId == cashierID
                                 select new
                                 {
                                     c.Authorization
                                 }
                                 ).FirstOrDefault();
                    if (query != null)
                    {
                        auth = query.Authorization;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect with database, network error");
            }
            return auth;
        }
    }
}
