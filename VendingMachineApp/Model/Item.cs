using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public abstract class Item
    {
        public int GroupId { get; set; }

        public int Price { get; set; }

        public abstract string Examine();

        public abstract string Use();
    }
}
