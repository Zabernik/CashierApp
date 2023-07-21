using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.DB
{
    public class Orders //There will be history of orders
    {
        [Key]
        public int Id { get; set; }
        public decimal OrderValue { get; set; }
        public decimal Rest { get; set; }
        public string CashierName { get; set; }
        [ForeignKey("Cashier")]
        public string CashierID { get; set; }
        public Cashier Cashier { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DataOfOrder { get; set; }
    }
    public class Cashier //There will be data about cashier
    {
        [Key]
        public string CashierId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PIN { get; set; }
    }
    public class CashierUpsell //There will be data about Upsell 
    {
        [Key]
        public string CashierUpsellId { get; set; }
        public string CashierName { get; set; }
        public decimal Total { get; set; }
        public decimal Sandwich { get; set; }
    }
    public class RestaurantUpsell
    {
        [Key]
        public string RestaurantUpsellId { get;set; }
        public decimal Total { get; set; }
        public decimal Sandwich { get; set; }
    }
}
