using System;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class CoffeeMachineValidatorTests
    {
        [Fact]
        public void ShouldReturnFalseForUnknownDrinkType()
        {
            string updates = "W";
            Assert.False(CoffeeMachineValidator.IsDrinkTypeValid(updates));
        }
        [Fact]
        public void ShouldReturnTrueForKnownDrinkType()
        {
            string updates = "T";
            Assert.True(CoffeeMachineValidator.IsDrinkTypeValid(updates));
        }
    }
}