using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApp.Enums
{
    /// <summary>
    /// IdProducts is enum for categorize food, like you can get specific extras to specific meal;<br />
    /// Cheese and Bacon you can add only to food less than 400 enum number<br />
    /// All extras had number from 500 to less 600<br />
    /// All Sets are form 200 to less 300<br />
    /// All Enlarged are form 300 to less 400<br />
    /// All salads are from 400 to less 500<br />
    /// All solo sandwich/wraps are from 000 to less 100
    /// </summary>
    public enum IdProducts
    {
        Cheesburger = 001,
        ChickenBurger = 002,
        TortillaBacon = 003,

        CheesburgerSet = 201,
        ChickenBurgerSet = 202,
        TortillaBaconSet = 203,

        ChickenBurgerEnlargedSet = 302,
        TortillaBaconEnlargedSet = 303,

        Piccante = 401,
        PiccanteSet = 411,

        Bacon = 501,
        Cheese = 502
    }
}
