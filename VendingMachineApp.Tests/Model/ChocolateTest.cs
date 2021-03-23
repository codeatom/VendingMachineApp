using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApp.Model;
using Xunit;

namespace VendingMachineApp.Tests.Model
{
    public class ChocolateTest
    {
        [Fact]
        public void ChocolateConstructionTest_TestForProperConstructionOfChocolateObject()
        {
            //Arrange
            int GroupId = 2;
            int Price = 20;
            string Examine = "Chocolate:\n   Cost is 20kr";
            string Usage = "Eat the chocolate.";

            //Act
            Chocolate chocolate = new Chocolate(2, 20);

            //Assert
            Assert.Equal(GroupId, chocolate.GroupId);
            Assert.Equal(Price, chocolate.Price);
            Assert.Equal(Examine, chocolate.Examine());
            Assert.Equal(Usage, chocolate.Use());
        }
    }
}
