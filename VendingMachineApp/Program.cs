using System;
using VendingMachineApp.Model;

namespace VendingMachineApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool appRunning = true;
            VendingMachine vendingMachine = new VendingMachine();

            while (appRunning)
            {
                ShowItemsInfo();
                DepositMoney(vendingMachine);
                PurchaseItem(vendingMachine);

                Console.WriteLine("\nYour puchased items are:");
                foreach (Item item in vendingMachine.ShowAll())
                {
                    Console.WriteLine(item.Examine());
                }

                Console.WriteLine(vendingMachine.EndTransaction());

                vendingMachine.GiveUsageInstructions(vendingMachine.CollateItems());

                Console.WriteLine("Have a nice day.\n\n ");

                vendingMachine.ClearVariables();
            }
        }

        public static void DepositMoney(VendingMachine vendingMachine)
        {
            string userInput = "";
            bool notDone = true;
            bool isInt = false;
            int deposit = 0;

            Console.WriteLine("Please deposit some money");
            Console.WriteLine("Entr D when you are done\n");

            while (notDone)
            {
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out deposit);

                if (isInt)
                {
                    if (vendingMachine.InsertMoney(deposit))
                    {
                        Console.WriteLine("Please deposit more money or enter D if you are done\n");
                    }
                    else
                    {
                        Console.WriteLine("That denomination is not valid\n");
                    }
                }
                else if (userInput == "D" || userInput == "d")
                {
                    notDone = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid entry\n");
                }
            }
        }

        public static void PurchaseItem(VendingMachine vendingMachine)
        {
            string userInput = "";
            bool notDone = true;
            bool isInt = false;
            int userChoice = 0;

            AskUserForChoice();

            while (notDone)
            {
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out userChoice);

                if (isInt)
                {
                    if (vendingMachine.Purchase(userChoice))
                    {
                        Console.WriteLine("Please make another choice or enter D if you are done\n");
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice\n");
                    }
                }
                else if (userInput == "D" || userInput == "d")
                {
                    notDone = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid choice\n");
                }
            }
        }

        public static void ShowItemsInfo()
        {
            Console.WriteLine("\n*******Welcome*******");
            Console.WriteLine("Available for purchase");
            Console.WriteLine("    Chips: 20kr    ");
            Console.WriteLine("    Chocolate: 25kr    ");
            Console.WriteLine("    Coke: 18kr    ");
            Console.WriteLine("    Water: 10kr    ");
            Console.WriteLine("**********************\n");
        }

        public static void AskUserForChoice()
        {
            Console.WriteLine("Make one or more choice by entering the choice number");
            Console.WriteLine("  1 for Chips  ");
            Console.WriteLine("  2 for Chocolate  ");
            Console.WriteLine("  3 for Coke  ");
            Console.WriteLine("  4 for Water  ");
            Console.WriteLine("Enter D when you are done\n");
        }
    }
}
