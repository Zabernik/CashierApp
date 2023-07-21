using CashierApp.Enums;
using CashierApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CashierApp.Classes.Products
{
    /// <summary>Class for all BaseProduct implemented into sales</summary>
    public class BaseProduct : IEquatable<BaseProduct>
    {
        /// <summary>Gets or sets the product identifier.</summary>
        /// <value>The product identifier gets from Enum IdProducts</value>
        public IdProducts ProductID { get; set; }
        /// <summary>Gets or sets the name of the product.</summary>
        /// <value>The name of the product.</value>
        protected string ProductName { get; set; }
        /// <summary>Gets or sets a value indicating whether this instance is sum to Upsell.</summary>
        /// <value>
        ///   <c>true</c> if this instance is sum to Upsell; otherwise, <c>false</c>.</value>
        protected bool IsUpsell { get; set; }
        /// <summary>Gets or sets the price.</summary>
        /// <value>The price in decimal.</value>
        public decimal Price { get; set; }

        /// <summary>Initializes a new instance of the <see cref="BaseProduct" /> class.</summary>
        /// <param name="productID">The product identifier by Enum IdProducts</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="isUpsell">if set to <c>true</c> [is sum Upsell].</param>
        /// <param name="price">The price in decimal.</param>
        public BaseProduct(IdProducts productID, string productName, bool isUpsell, decimal price) 
        { 
            ProductID = productID;
            ProductName = productName;
            IsUpsell = isUpsell;
            Price = price;
        }
        /// <summary>Initializes a new instance of the <see cref="BaseProduct" /> class.</summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="isUpsell">if set to <c>true</c> [is sum Upsell].</param>
        public BaseProduct(string productName, bool isUpsell)
        {
            ProductName = productName;
            IsUpsell = isUpsell;
        }

        /// <summary>Converts to string to inform user about all data products.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"Dane produktu {ProductName} to: \n" +
                   $"ProductID - {ProductID} \n" +
                   $"IsUpsell - {IsUpsell} \n" +
                   $"Cena - {Price} \n";
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> if the current object Price is equal to the <paramref name="other" /> Price; otherwise, <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span>.
        /// </returns>
        public bool Equals(BaseProduct other)
        {
            if (this.Price == other.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>Implements the operator ==.</summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(BaseProduct obj1, BaseProduct obj2)
        {
            if (obj1.Price == obj2.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>Implements the operator !=.</summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(BaseProduct obj1, BaseProduct obj2)
        {
            if (obj1.Price != obj2.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>Checks the product price and return a MessageBox with data about Price.</summary>
        public void CheckProductPrice()
        {
            if (MainWindow.CheckPrice is true)
            {
                MessageBox.Show($"{this.ProductName} kosztuje {this.Price} PLN");
            }
        }
        /// <summary>Checks the product ingredients and return a MessageBox with data about Ingredients.</summary>
        public void CheckProductIngredients()
        {
            if (MainWindow.CheckIngredients is true)
            {
                MessageBox.Show($"{this.ProductName} zawiera: \n" +
                    $"{this.CheckIngredients()}");
            }
        }
        /// <summary>This return information about not implemented in Products data about ingredients</summary>
        /// <returns>"There isn't composition entered"</returns>
        public virtual string CheckIngredients()
        {
            return "Brak wprowadzonego składu";
        }
    }
}
