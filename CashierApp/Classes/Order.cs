using CashierApp.Classes.Products;
using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CashierApp.Classes.DB;

namespace CashierApp.Classes
{
    /// <summary>Class for delete and add products, contains all data about order picking</summary>
    public class Order
    {
        /// <summary>Gets or sets the identifier of order</summary>
        /// <value>The identifier.</value>
        public static int Id { get; set; }
        /// <summary>Gets or sets the order value by decimal.</summary>
        /// <value>The order value.</value>
        public static decimal OrderValue { get; set; }
        /// <summary>List of IdProducts (which sets on enum) on your Order</summary>
        /// <value>The ID of products</value>
        public static List<IdProducts> Products { get; set; }
        /// <summary>List of Price Products on your Order</summary>
        /// <value>The price products.</value>
        public static List<decimal> PriceProducts { get; set; }
        /// <summary>Initializes a new instance of the <see cref="Order" /> class.</summary>
        /// <param name="id">The identifier.</param>
        public Order(int id)
        {
            if (id == 1)
            {
                TransferDataID(id);
            }
            else
            {
                Id = id;
            }
            Products = new List<IdProducts>();
            PriceProducts = new List<decimal>();

        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{OrderValue} PLN";
        }
        /// <summary>Method for adding products to your Order; list Products get's id of object, list PriceProducts get's decimal value of object</summary>
        /// <param name="obj">The object of product adding to Order</param>
        public static void AddProduct(BaseProduct obj)
        {
            if (MainWindow.CheckPrice is false && MainWindow.CheckIngredients is false)
            {
                Products.Add(obj.ProductID);
                PriceProducts.Add(obj.Price);
                OrderValue += obj.Price;
            }
        }
        /// <summary>Method for adding extras to products on your Order; Checking if extras can be add to products (not to all can be, that's depend on number id)</summary>
        /// <param name="obj">The object. of extras</param>
        /// <param name="index">The index to check if extras can be add to product</param>
        public static void AddExtra(BaseExtra obj, int index)
        {
            if (MainWindow.CheckPrice is false && MainWindow.CheckIngredients is false)
            {
                try
                {
                    bool CanBeExtra = (int)Products[index] < 400;
                    if (CanBeExtra is true)
                    {
                        PriceProducts.Insert(index + 1, obj.Price);
                        Products.Insert(index + 1, obj.ExtraID);
                        OrderValue = PriceProducts.Sum();
                    }
                    else
                    {
                        MessageBox.Show("Nie można dodać dodatku");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie można dodać dodatku");
                }
            }
        }
        /// <summary>Method for deleting products from list Products/PriceProducts</summary>
        /// <param name="index">The index of product to delete</param>
        public static void DeleteProduct(int index)
        {
            try
            {
                Products.RemoveAt(index);
                PriceProducts.RemoveAt(index);
                OrderValue = PriceProducts.Sum();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Najpierw zaznacz produkt do usunięcia");
            }
            try
            {
                while ((int)Products[index] > 500)
                {
                    Products.RemoveAt(index);
                    PriceProducts.RemoveAt(index);
                }
                OrderValue = PriceProducts.Sum();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        /// <summary>Transfers to DB the identifier of new order.</summary>
        /// <param name="id">The identifier new order</param>
        private void TransferDataID(int id)//Transfer ID to db
        {
            try
            {
                using (DataBaseContext conn = new DataBaseContext())
                {
                    while (conn.Orders.Any(idExist => idExist.Id == id))
                    {
                        id += 1;
                        Id = id;
                    }
                    Orders newOrder = new Orders { Id = id, IsFinished = false, DataOfOrder = DateTime.Now, CashierName = User.Name, CashierID = User.CashierId };
                    conn.Add<Orders>(newOrder);
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
