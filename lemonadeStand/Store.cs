using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadeStand
{
    class Store
    {
        public List<Item> items;

        public Store()
        {
            items = new List<Item> { new Lemon(), new Cup(), new Sugar(), new Ice() };
        }
    }
}
