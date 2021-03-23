using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApp.Model;
using Xunit;

namespace VendingMachineApp.Tests.Model
{
    public class CokeTest
    {
        [Fact]
        public void CokeConstructionTest_TestForProperConstructionOfCokeObject()
        {
            //Arrange
            int GroupId = 3;
            int Price = 18;
            string Examine = "Coke:\n   Cost is 18kr";
            string Usage = "Drink the coke.";

            //Act
            Coke coke = new Coke(3, 18);

            //Assert
            Assert.Equal(GroupId, coke.GroupId);
            Assert.Equal(Price, coke.Price);
            Assert.Equal(Examine, coke.Examine());
            Assert.Equal(Usage, coke.Use());
        }
    }
}
