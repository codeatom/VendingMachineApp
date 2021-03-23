using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public class Coke : Item
    {
        public Coke(int groupId, int price)
        {
            GroupId = groupId;
            Price = price;
        }

        public override string Examine()
        {
            return "Coke:\n   Cost is " + Price + "kr";
        }

        public override string Use()
        {
            return "Drink the coke.";
        }
    }
}
