using CashierApp.Classes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes
{
    /// <summary>Class for specifie a cashier like ID/Name/Surname employee</summary>
    public class User
    {
        public static string Name { get; set; }
        public static string CashierId { get; set; }

        public string GetName(string PIN)
        {
            string Name = default;
            using (DataBaseContext ctx = new DataBaseContext())
            {
                var query = (from c in ctx.Cashier
                              where c.PIN == PIN
                              select new
                              {
                                  c.Name ,
                                  c.Surname,
                              }
                             ).FirstOrDefault();

                if (query != null)
                {
                    Name = query.Name + " " + query.Surname;
                }
            }
            return Name;
        }
        public string GetID(string PIN)
        {
            string Data = default;
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
                return Data;
            }
        }

    }
}
