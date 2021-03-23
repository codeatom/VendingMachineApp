using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApp.Model;
using Xunit;

namespace VendingMachineApp.Tests.Model
{
    public class ChipsTest
    {
        [Fact]
        public void ChipsConstructionTest_TestForProperConstructionOfChipsObject()
        {
            //Arrange
            int GroupId = 1;
            int Price = 20;
            string Examine = "Chips:\n   Cost is 20kr";
            string Usage = "Eat the chips.";

            //Act
            Chips chips = new Chips(1, 20);

            //Assert
            Assert.Equal(GroupId, chips.GroupId);
            Assert.Equal(Price, chips.Price);
            Assert.Equal(Examine, chips.Examine());
            Assert.Equal(Usage, chips.Use());
        }
    }
}
