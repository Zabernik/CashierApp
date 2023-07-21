using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products
{
    /// <summary>Class for all BaseExtra implemented into sales</summary>
    public class BaseExtra : BaseProduct
    {
        /// <summary>Gets or sets the extra identifier by Enum IdProducts</summary>
        /// <value>The extra identifier gets by Enum IdProducts</value>
        public IdProducts ExtraID { get; set; }
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        protected string Name { get; set; }
        /// <summary>Gets or sets the price.</summary>
        /// <value>The price in decimal.</value>
        public decimal Price { get; set; }
        /// <summary>Parameter is set to always true to sum Upsell</summary>
        protected bool IsUpsell = true;

        /// <summary>Initializes a new instance of the <see cref="BaseExtra" /> class who gets base by BaseProduct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="price">The price by decimal.</param>
        /// <param name="extraID">The extra identifier by Enum IdProducts.</param>
        public BaseExtra(string name, decimal price, IdProducts extraID) : base(extraID,name,true,price) 
        { 
            ExtraID = extraID;
            Name = name;
            Price = price;
        }
    }
}
