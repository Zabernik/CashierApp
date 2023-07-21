using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.DB
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = CashierApp.db");
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<CashierUpsell> CashierUpsell { get; set; }
        public DbSet<RestaurantUpsell> RestUpsell { get; set; }
    }
}
