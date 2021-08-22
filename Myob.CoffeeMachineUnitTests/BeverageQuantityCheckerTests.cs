using System;
using System.Linq;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class BeverageQuantityCheckTests
    {
        private BeverageQuantityChecker _beverageQuantityChecker = new BeverageQuantityChecker();

        [Fact]
        public void ShouldAddSoldOutDrinkList_WhenCoffeeIsSoldOut()
        {
            //Arrange
            string[] orderData = {"11", "10", "10", "10"};
            
            //Act
            var orderHistory = BuildOrderHistory(orderData);
            var isSoldOut = _beverageQuantityChecker.CheckIfBeverageSoldOut(orderHistory);
            
            //Assert
            Assert.True(isSoldOut);
            Assert.Equal("coffee", _beverageQuantityChecker._soldOutDrinkTypeList.First());
        }
        
        [Fact]
        public void ShouldAddSoldOutDrinkList_WhenChocolateIsSoldOut()
        {
            //Arrange
            string[] orderData = {"10", "11", "10", "10"};
            
            //Act
            var orderHistory = BuildOrderHistory(orderData);
            var isSoldOut = _beverageQuantityChecker.CheckIfBeverageSoldOut(orderHistory);
            
            //Assert
            Assert.True(isSoldOut);
            Assert.Equal("chocolate", _beverageQuantityChecker._soldOutDrinkTypeList.First());
        }

        [Fact]
        public void ShouldAddSoldOutDrinkList_WhenTeaIsSoldOut()
        {
            //Arrange
            string[] orderData = {"10", "10", "11", "10"};
            
            //Act
            var orderHistory = BuildOrderHistory(orderData);
            var isSoldOut = _beverageQuantityChecker.CheckIfBeverageSoldOut(orderHistory);
            
            //Assert
            Assert.True(isSoldOut);
            Assert.Equal("tea", _beverageQuantityChecker._soldOutDrinkTypeList.First());
        }

        [Fact]
        public void ShouldNotAddSoldOutDrinkList_WhenNoDrinkIsSoldOut()
        {
            //Arrange
            string[] orderData = {"11", "11", "11", "11"};
            
            //Act
            var orderHistory = BuildOrderHistory(orderData);
            var isSoldOut = _beverageQuantityChecker.CheckIfBeverageSoldOut(orderHistory);
            
            //Assert
            Assert.True(isSoldOut);
            Assert.Contains("tea", _beverageQuantityChecker._soldOutDrinkTypeList);
            Assert.Contains("chocolate", _beverageQuantityChecker._soldOutDrinkTypeList);
            Assert.Contains("coffee", _beverageQuantityChecker._soldOutDrinkTypeList);
            Assert.Contains("orange juice", _beverageQuantityChecker._soldOutDrinkTypeList);
        }
        
        [Fact]
        public void ShouldAddSoldOutDrinkList_WhenMultipleDrinksAreSoldOut()
        {
            //Arrange
            string[] orderData = {"9", "9", "9", "9"};
            
            //Act
            var orderHistory = BuildOrderHistory(orderData);
            var isSoldOut = _beverageQuantityChecker.CheckIfBeverageSoldOut(orderHistory);
            
            //Assert
            Assert.False(isSoldOut);
            Assert.False(_beverageQuantityChecker._soldOutDrinkTypeList.Any());
        }

        private OrderHistory BuildOrderHistory(string[] orderData)
        {
            try
            {
                OrderHistory orderHistory = new OrderHistory();
                orderHistory.CoffeeSales = Convert.ToInt32(orderData[0]);
                orderHistory.ChocolateSales = Convert.ToInt32(orderData[1]);
                orderHistory.TeaSales = Convert.ToInt32(orderData[2]);
                orderHistory.OrangeJuiceSales = Convert.ToInt32(orderData[3]);
                return orderHistory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}