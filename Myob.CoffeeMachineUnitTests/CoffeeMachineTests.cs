/*using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachine coffeeMachine = new CoffeeMachine(new CoffeeMachineConsolePresenter());
        [Fact]
        public void ShouldMakeOneTeaWithNoSugarCorrectly()
        {
            string updates = "T:0:0,0.4";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Tea with no sugar - and therefore no stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneCoffeeWithNoSugarCorrectly()
        {
            string updates = "C:0:0,0.6";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Coffee with no sugar - and therefore no stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneChocolateWithNoSugarCorrectly()
        {
            string updates = "H:0:0,0.5";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Chocolate with no sugar - and therefore no stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldNotMakeDrinkWithUnknownDrinkType()
        {
            string updates = "K:0:0,0.1";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Sorry we don't know this drink", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneChocolateWithTwoSugarsWithStickCorrectly()
        {
            string updates = "H:2:0,0.5";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Chocolate with 2 sugars and a stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneChocolateWithOneSugarWithStickCorrectly()
        {
            string updates = "H:1:0,0.5";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Chocolate with 1 sugar and a stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneDrinkWithNoSugarAndNoStickForIncompleteOrderCorrectly()
        {
            string updates = "H::,0.5";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Chocolate with no sugar - and therefore no stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeOneDrinkWithOneSugarWithoutStickCorrectly()
        {
            string updates = "H:1:,0.5";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Chocolate with 1 sugar and a stick", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldNotMakeDrinkForUnderPaidOrders()
        {
            string updates = "H:1:0,0.2";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Sorry you didn't pay enough money", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldMakeDrinkWithCorrectAmountOfChangeForOverPaidOrders()
        {
            string updates = "T:1:0,1";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Drink maker makes 1 Tea with 1 sugar and a stick, with 0.6 euros of change", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        [Fact]
        public void ShouldNotMakeDrinkIfCustomerDidNotPay()
        {
            string updates = "T:1:0";
            coffeeMachine.MakeDrink(updates);
            Assert.Equal("Sorry, you need to pay for your order", coffeeMachine.coffeeMachineConsolePresenter.OutputText);
        }
        
    }
}*/