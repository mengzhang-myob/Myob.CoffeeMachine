using Myob.CoffeeMachineDomain;

namespace Myob.CoffeeMachineUnitTests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachine coffeeMachine = new CoffeeMachine(new CoffeeMachineConsolePresenter());

        /*[Fact]
        public void ShouldReExecuteMakeDrinkOrderWhenUserWantsToOrderMore()
        {
            //Arrange
            string updates = "Y";

            //Act
            var shouldMakeMoreOrder = CoffeeMachine.ShouldMakeMoreOrder(updates);
            
            //Assert
            Assert.Equal("Orange juice cannot have extra sugar", ex.Message);
        }*/
    }
}