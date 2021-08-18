using System;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class OrderHistoryManagerTests
    {
        private readonly OrderCreator _orderCreator = new OrderCreator();
        private readonly OrderHistoryManager _orderHistoryManager= new OrderHistoryManager();
        [Fact]
        public void ShouldRetrieveCorrectOrderHistory_WithMultipleCorrectlyPaidOrder()
        {
            //Arrange
            string[] updates = {"T:1:0,0.4", "H:1:0,0.5", "C:1:0,0.6", "O:0:0,0.6"};

            //Act
            foreach (string userInput in updates)
            {
                var orderInput = userInput.Split(",");
                _orderHistoryManager.SaveOrder(_orderCreator.BuildOrderCreator(orderInput).CreateOrder());
            }
            var orderHistory = _orderHistoryManager.RetrieveOrderHistory();

            //Assert
            Assert.Equal(1, orderHistory.ChocolateSales);
            Assert.Equal(1, orderHistory.OrangeJuiceSales);
            Assert.Equal(1, orderHistory.CoffeeSales);
            Assert.Equal(1, orderHistory.TeaSales);
            Assert.Equal(2.1m, orderHistory.Profit);
        }
        [Fact]
        public void ShouldRetrieveCorrectOrderHistory_WithOneCorrectlyPaidOrder()
        {
            //Arrange
            string[] updates = {"T:1:0,0.4"};

            //Act
            var orderInput = updates[0].Split(",");
            _orderHistoryManager.SaveOrder(_orderCreator.BuildOrderCreator(orderInput).CreateOrder());
            var orderHistory = _orderHistoryManager.RetrieveOrderHistory();

            //Assert
            Assert.Equal(1, orderHistory.TeaSales);
            Assert.Equal(0.4m, orderHistory.Profit);
        }
    }
}