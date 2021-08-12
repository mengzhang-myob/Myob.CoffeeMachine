using System;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class OrderCreatorTests
    {
        OrderCreator _orderCreator = new OrderCreator();
        [Theory]
        [InlineData("T:1:0")]
        [InlineData("H:1:0")]
        [InlineData("C:1:0")]
        [InlineData("O:1:0")]
        public void ShouldThrowException_WithValidOrderDetail_WithOutPaymentAmount(string orderWithoutPaymentAmount)
        {
            //Arrange
            string [] updates = {orderWithoutPaymentAmount};
            
            
            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("This Order is in the wrong format", ex.Message);
        }
        [Theory]
        [InlineData("T:f.:0", "0.4")]
        [InlineData("T:.:0", "0.4")]
        [InlineData("T:0.3:0", "0.4")]
        [InlineData("T:3fl:0", "0.4")]
        public void ShouldThrowException_IfOrderDetailHasKnownDrinkType_WithIncorrectSugarFormat(string invalidOrderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {invalidOrderDetail, paymentAmount};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Sorry, the amount of sugar you entered is invalid", ex.Message);
        }
        [Fact]
        public void ShouldThrowException_WithUnknownDrinkType()
        {
            //Arrange
            string[] updates = {"G:1:0", "0.4"};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Sorry, we don't have the drink you ordered", ex.Message);
        }
        
        [Fact]
        public void ShouldThrowException_WithInvalidOrderDetails_AndValidPaymentAmount()
        {
            //Arrange
            string[] updates = {"G:0", "0.4"};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Please ensure the format of your order is 'Drink type:Amount of sugar:Number of stick' or 'Drink type::'", ex.Message);
        }
        [Fact]
        public void ShouldThrowException_WithValidOrderDetails_AndUnderpaidPaymentAmount()
        {
            //Arrange
            string[] updates = {"T:1:0", "0.1"};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("You did not pay enough money", ex.Message);
        }
        [Fact]
        public void ShouldThrowException_WithValidOrderDetails_AndInvalidPaymentAmountFormat()
        {
            //Arrange
            string[] updates = {"T:1:0", "lol"};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Wrong format, your payment detail should be a decimal value", ex.Message);
        }
        [Fact]
        public void ShouldThrowException_WithInvalidOrderDetailsThatHasExtraHotOrangeJuice_AndValidPaymentAmountFormat()
        {
            //Arrange
            string[] updates = {"Oh:0:0", "0.6"};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Orange juice cannot be made extra hot", ex.Message);
        }
        [Theory]
        [InlineData("O:1:0", "0.6")]
        [InlineData("O:1:", "0.6")]
        public void ShouldThrowException_WithOrderDetailsThatHasOrangeJuiceAndSugar_AndValidPaymentAmountFormat(string invalidOrderDetailsOrangeJuiceWithSugar, string paymentDetail)
        {
            //Arrange
            string[] updates = {invalidOrderDetailsOrangeJuiceWithSugar, paymentDetail};

            //Act
            var ex = Assert.Throws<ArgumentException>(() => _orderCreator.BuildOrderCreator(updates));
            
            //Assert
            Assert.Equal("Orange juice cannot have extra sugar", ex.Message);
        }
        
        [Theory]
        [InlineData("O:0:0", "0.6")]
        [InlineData("O::", "0.6")]
        [InlineData("O:0:", "0.6")]
        public void ShouldMakeOrangeJuice_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsWithOrangeJuice, string paymentDetail)
        {
            //Arrange
            string[] updates = {validOrderDetailsWithOrangeJuice, paymentDetail};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("orange juice", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.6m, order.PaymentAmount);
            Assert.Equal(0, order.AmountOfSugar);
            Assert.False(order.IsExtraHot);
        }
        
        [Theory]
        [InlineData("T:1:1", "0.4")]
        [InlineData("T:1:", "0.4")]
        public void ShouldMakeTea_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("tea", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.4m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.False(order.IsExtraHot);
        }
        [Theory]
        [InlineData("Th:1:1", "0.4")]
        [InlineData("Th:1:", "0.4")]
        public void ShouldMakeExtraHotTea_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("tea", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.4m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.True(order.IsExtraHot);
        }
        [Theory]
        [InlineData("C:1:1", "0.6")]
        [InlineData("C:1:", "0.6")]
        public void ShouldMakeCoffee_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("coffee", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.6m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.False(order.IsExtraHot);
        }
        [Theory]
        [InlineData("Ch:1:0", "0.6")]
        [InlineData("Ch:1:", "0.6")]
        public void ShouldMakeExtraHotCoffee_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("coffee", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.6m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.True(order.IsExtraHot);
        }
        [Theory]
        [InlineData("H:1:0", "0.5")]
        [InlineData("H:1:", "0.5")]
        public void ShouldMakeChocolate_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("chocolate", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.5m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.False(order.IsExtraHot);
        }
        
        [Theory]
        [InlineData("Hh:1:0", "0.5")]
        [InlineData("Hh:1:", "0.5")]
        public void ShouldMakeExtraHotChocolate_WithValidOrderDetails_AndValidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("chocolate", order.DrinkType);
            Assert.Equal(0, order.AmountOfChange);
            Assert.Equal(0.5m, order.PaymentAmount);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.True(order.IsExtraHot);
        }
        
        [Theory]
        [InlineData("Hh:1:0", "1")]
        [InlineData("Hh:1:", "1")]
        public void ShouldMakeExtraHotTea_WithValidOrderDetails_AndOverPaidPaymentAmount(string validOrderDetailsForTeaWithOneAmountOfSugar, string validPaymentAmount)
        {
            //Arrange
            string[] updates = {validOrderDetailsForTeaWithOneAmountOfSugar, validPaymentAmount};

            //Act
            var orderCreator = _orderCreator.BuildOrderCreator(updates);
            var order = orderCreator.CreateOrder();
            
            //Assert
            Assert.Equal("chocolate", order.DrinkType);
            Assert.Equal(1m, order.PaymentAmount);
            Assert.Equal(0.5m, order.AmountOfChange);
            Assert.Equal(1, order.AmountOfSugar);
            Assert.True(order.IsExtraHot);
        }
    }
}