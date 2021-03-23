using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public class Chocolate : Item
    {
        public Chocolate(int groupId, int price)
        {
            GroupId = groupId;
            Price = price;
        }

        public override string Examine()
        {
            return "Chocolate:\n   Cost is " + Price + "kr";
        }

        public override string Use()
        {
            return "Eat the chocolate.";
        }
    }
}
