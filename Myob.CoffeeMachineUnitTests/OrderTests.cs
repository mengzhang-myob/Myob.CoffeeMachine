using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    //Inline for testing negative edge case
    // 0, -1, -0.1
    // a, ?
    // [1, 0.5]
    // [0.5, 0]
    public class OrderTests
    {
        Order _order = new Order();
        [Fact]
        public void ShouldSetDrinkTypeToUnknownForUnknownDrink()
        {
            _order.SetDrinkType("W");
            Assert.Equal("Unknown", _order.DrinkType);
        }
        [Fact]
        public void ShouldSetDrinkTypeForKnownDrink()
        {
            _order.SetDrinkType("T");
            Assert.Equal("Tea", _order.DrinkType);
        }
        [Fact]
        public void ShouldNotSetSugarWithInvalidInput()
        {   
            _order.SetDrinkType("T");
            _order.SetNumberOfSugar("string");
            Assert.Equal(0, _order.AmountOfSugar());
        }
        [Fact]
        public void ShouldSetSugarWithValidInput()
        {
            _order.SetDrinkType("T");
            _order.SetNumberOfSugar("3");
            Assert.Equal(3, _order.AmountOfSugar());
        }
        [Fact]
        public void SetActualPriceAndAmountOfChangeCorrectly()
        {
            _order.SetDrinkType("T");
            _order.SetPaymentAmount("1");
            Assert.Equal((decimal) 0.6, _order.AmountOfChange);
        }
        
    }
}