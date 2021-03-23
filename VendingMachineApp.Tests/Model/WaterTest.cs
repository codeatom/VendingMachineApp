using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApp.Model;
using Xunit;

namespace VendingMachineApp.Tests.Model
{
    public class WaterTest
    {
        [Fact]
        public void WaterConstructionTest_TestForProperConstructionOfWaterObject()
        {
            //Arrange
            int GroupId = 4;
            int Price = 10;
            string Examine = "Water:\n   Cost is 10kr";
            string Usage = "Drink the water.";

            //Act
            Water water = new Water(4, 10);

            //Assert
            Assert.Equal(GroupId, water.GroupId);
            Assert.Equal(Price, water.Price);
            Assert.Equal(Examine, water.Examine());
            Assert.Equal(Usage, water.Use());
        }
    }
}
