using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public class Chips : Item
    {
        public Chips(int groupId, int price)
        {
            GroupId = groupId;
            Price = price;
        }

        public override string Examine()
        {
            return "Chips:\n   Cost is " + Price + "kr";
        }

        public override string Use()
        {
            return "Eat the chips.";
        }
    }
}
