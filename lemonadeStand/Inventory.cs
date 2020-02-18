using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadeStand
{

    class Inventory
    {
        public List<Item> items;
        public double walletBalance;

        public Inventory()
        {
            items = new List<Item> { new Lemon(), new Cup(), new Sugar(), new Ice() };
            walletBalance = 20.00;
        }
    }
}
