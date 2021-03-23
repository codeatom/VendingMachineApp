using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public interface IVending
    {
        bool InsertMoney(int deposit);

        bool Purchase(int groupId);

        public List<Item> ShowAll();

        string EndTransaction();
    }
}
