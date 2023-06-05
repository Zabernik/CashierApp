﻿using CashierApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Classes.Products
{
    public class BaseProduct : IEquatable<BaseProduct>
    {
        public IdProducts ProductID { get; set; }
        protected string ProductName { get; set; }
        protected bool IsUpsell { get; set; }
        protected decimal Price { get; set; }

        public BaseProduct(IdProducts productID, string productName, bool isUpsell, decimal price) 
        { 
            ProductID = productID;
            ProductName = productName;
            IsUpsell = isUpsell;
            Price = price;
        }
        public BaseProduct(string productName, bool isUpsell)
        {
            ProductName = productName;
            IsUpsell = isUpsell;
        }

        public override string ToString()
        {
            return $"Dane produktu {ProductName} to: " +
                $"ProductID - {ProductID} " +
                $"IsUpsell - {IsUpsell} " +
                $"Cena - {Price} ";
        }

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

        public void AddExtra(BaseExtra obj)
        {
            this.Price += obj.Price;
        }
        public void AddToBill(Order obj)
        {
            obj.OrderValue += this.Price;
        }
    }
}
