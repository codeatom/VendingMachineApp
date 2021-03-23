using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public class Water : Item
    {
        public Water(int groupId, int price)
        {
            GroupId = groupId;
            Price = price;
        }

        public override string Examine()
        {
            return "Water:\n   Cost is " + Price + "kr";
        }

        public override string Use()
        {
            return "Drink the water.";
        }
    }
}
