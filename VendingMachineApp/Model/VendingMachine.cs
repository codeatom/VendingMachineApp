using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Model
{
    public class VendingMachine : IVending
    {
        public readonly int[] moneyDenomination = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private List<Item> stockedItems = new List<Item>();
        private List<Item> purchasedItems = new List<Item>();
        private int moneyPool = 0;

        public VendingMachine()
        {
            AddStockedItems();
        }

        public bool InsertMoney(int deposit)
        {
            foreach (int moneyDenom in moneyDenomination)
            {
                if (moneyDenom == deposit)
                {
                    moneyPool += deposit;
                    Console.WriteLine("\nYour total deposit is " + moneyPool);
                    return true;
                }
            }

            return false;
        }

        public bool Purchase(int groupId)
        {
            foreach (Item item in stockedItems)
            {
                if (item.GroupId == groupId && DepositIsEnough(item.Price))
                {
                    purchasedItems.Add(item);
                    moneyPool -= item.Price;
                    return true;
                }
            }

            return false;
        }

        public List<Item> ShowAll()
        {
            return purchasedItems;
        }

        public string EndTransaction()
        {
            foreach (int i in moneyDenomination)
            {
                if (moneyPool >= moneyDenomination[i] && moneyPool % moneyDenomination[i] == 0)
                {
                    return "\nYour change is " + moneyPool / moneyDenomination[i] + " * " + moneyDenomination[i] + "kr\n";
                }
                else if (moneyPool >= moneyDenomination[i] && moneyPool % moneyDenomination[i] != 0)
                {
                    return "\nYour change is " + moneyPool / moneyDenomination[i] + " * " + moneyDenomination[i] + "kr and " + moneyPool % moneyDenomination[i] + " * 1kr\n";
                }
            }

            return null;
        }

        public bool DepositIsEnough(int itemPrice)
        {
            return moneyPool >= itemPrice;
        }

        public void GiveUsageInstructions(List<Item> collatedItems)
        {
            foreach (Item item in collatedItems)
            {
                Console.WriteLine(item.Use());
            }
        }               

        public List<Item> CollateItems()
        {
            List<int> itemGroupId = new List<int>();
            List<Item> collatedItems = new List<Item>();

            foreach (Item item in purchasedItems)
            {
                if (!itemGroupId.Contains(item.GroupId))
                {
                    collatedItems.Add(item);
                    itemGroupId.Add(item.GroupId);
                }
            }

            return collatedItems;
        }        

        public int ShowTotalDeposit()
        {
            return moneyPool;
        }

        public void ClearVariables()
        {
            moneyPool = 0;
            purchasedItems.Clear();
        }

        public void AddStockedItems()
        {
            //stockedItems are assumed to be infinite 
            stockedItems.Add(new Chips(1, 20));
            stockedItems.Add(new Chocolate(2, 20));
            stockedItems.Add(new Coke(3, 18));
            stockedItems.Add(new Water(4, 10));
        }
    }
}
