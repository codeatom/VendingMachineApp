using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApp.Model;
using Xunit;

namespace VendingMachineApp.Tests.Model
{
    public class VendingMachineTest
    {
        [Fact]
        public void InsertMoney_TestThatUserCanInsertMoneyInTheAllowedDenominations()
        {
            //Arrange
            int Amount = 61;

            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(10);
            vendingMachine.InsertMoney(1);

            //Assert
            Assert.Equal(Amount, vendingMachine.ShowTotalDeposit());
        }

        [Fact]
        public void Purchase_TestThatUserChoiceObjectsAreCreatedAndAddedToList()
        {
            //Arrange
            int object_1_groupId = 1;
            int object_1_price = 20;
            int object_2_groupId = 2;
            int object_2_price = 20;
            int object_3_groupId = 3;
            int object_3_price = 18;
            int object_4_groupId = 4;
            int object_4_price = 10;

            //Act
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.InsertMoney(500);

            vendingMachine.Purchase(1);
            vendingMachine.Purchase(3);
            vendingMachine.Purchase(2);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(4);

            //Assert
            Assert.Equal(object_1_groupId, vendingMachine.ShowAll()[0].GroupId);
            Assert.Equal(object_1_price, vendingMachine.ShowAll()[0].Price);

            Assert.Equal(object_3_groupId, vendingMachine.ShowAll()[1].GroupId);
            Assert.Equal(object_3_price, vendingMachine.ShowAll()[1].Price);

            Assert.Equal(object_2_groupId, vendingMachine.ShowAll()[2].GroupId);
            Assert.Equal(object_2_price, vendingMachine.ShowAll()[2].Price);

            Assert.Equal(object_1_groupId, vendingMachine.ShowAll()[3].GroupId);
            Assert.Equal(object_1_price, vendingMachine.ShowAll()[3].Price);

            Assert.Equal(object_4_groupId, vendingMachine.ShowAll()[4].GroupId);
            Assert.Equal(object_4_price, vendingMachine.ShowAll()[4].Price);
        }

        [Fact]
        public void EndTransaction_TestThatCorrectAmountOfChangeIsReturnedToUser()
        {
            //Arrange
            string result = "\nYour change is 12 * 5kr and 2 * 1kr\n";

            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(100);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(3);

            //Assert
            Assert.Equal(result, vendingMachine.EndTransaction());
        }

        [Fact]
        public void CollateItems_TestThatAListThatContainsOnlyOneObjectOfEachClassIsReturned()
        {
            //Arrange
            int listCount = 2;

            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.InsertMoney(500);

            vendingMachine.Purchase(1);
            vendingMachine.Purchase(2);
            vendingMachine.Purchase(2);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(2);

            //Act
            List<Item> collateItemsList = vendingMachine.CollateItems();

            //Assert
            Assert.Equal(listCount, vendingMachine.CollateItems().Count);
        }

        [Fact]
        public void ClearVariables_TestThatGivenVariablesAreSetToDefaltValues()
        {
            //Arrange
            int listCount = 0;
            int deposit = 0;

            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.InsertMoney(500);

            vendingMachine.Purchase(1);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(2);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(1);

            //Act
            vendingMachine.ClearVariables();

            //Assert
            Assert.Equal(listCount, vendingMachine.ShowAll().Count);
            Assert.Equal(deposit, vendingMachine.ShowTotalDeposit());
        }

        [Fact]
        public void DepositIsEnough_TestThatAvailableUserDepositIsGreaterThanThePriceOfARequestedObject()
        {
            //Arrange
            bool isTrue = true;
            bool isFalse = false;
            VendingMachine vendingMachine = new VendingMachine();

            //Act
            vendingMachine.InsertMoney(10);
            vendingMachine.InsertMoney(20);
            vendingMachine.Purchase(1);
            bool result1 = vendingMachine.DepositIsEnough(vendingMachine.ShowAll()[0].Price);

            //Assert
            Assert.Equal(isFalse, result1);


            //Act
            vendingMachine.InsertMoney(10);
            bool result2 = vendingMachine.DepositIsEnough(vendingMachine.ShowAll()[0].Price);

            //Assert
            Assert.Equal(isTrue, result2);
        }
    }
}
