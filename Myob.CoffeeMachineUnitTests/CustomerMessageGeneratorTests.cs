using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class CustomerMessageGeneratorTests
    {
        private readonly CustomerMessageGenerator _customerMessageGenerator = new CustomerMessageGenerator();
        private readonly OrderCreator _orderCreator = new OrderCreator();

        [Theory]
        [InlineData("C:1:1", "0.6")]
        [InlineData("C:1:", "0.6")]
        public void ShouldGenerateCorrectMessage_WhenOrderHasCoffee_WithOneAmountOfSugar_WithCorrectPayment(
            string orderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker makes 1 coffee with 1 sugar and a stick", customerMessage);
        }

        [Theory]
        [InlineData("Ch:2:1", "0.6")]
        [InlineData("Ch:2:", "0.6")]
        public void
            ShouldGenerateCorrectMessage_WhenOrderExtraHotCoffee_WithMoreThanOneAmountOfSugar_WithCorrectPayment(
                string orderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker will make an extra hot coffee with 2 sugars and a stick", customerMessage);
        }

        [Theory]
        [InlineData("Ch:1:1", "0.6")]
        [InlineData("Ch:1:", "0.6")]
        public void ShouldGenerateCorrectMessage_WhenOrderExtraHotCoffee_WithOneAmountOfSugar_WithCorrectPayment(
            string orderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker will make an extra hot coffee with 1 sugar and a stick", customerMessage);
        }

        [Theory]
        [InlineData("Ch:0:0", "0.6")]
        [InlineData("Ch:0:", "0.6")]
        [InlineData("Ch::", "0.6")]
        public void ShouldGenerateCorrectMessage_WhenOrderHasExtraHotCoffee_WithoutSugar_WithCorrectPayment(
            string orderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker will make an extra hot coffee with no sugar", customerMessage);
        }

        [Theory]
        [InlineData("O:0:0", "0.6")]
        [InlineData("O:0:", "0.6")]
        public void ShouldGenerateCorrectMessage_WhenOrderHasOrangeJuice_WithoutSugar_WithCorrectPayment(
            string orderDetail, string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker will make one orange juice", customerMessage);
        }

        [Theory]
        [InlineData("C:0:0", "0.6")]
        [InlineData("C:0:", "0.6")]
        public void ShouldGenerateCorrectMessage_WhenOrderHasCoffee_WithoutSugar_WithCorrectPayment(string orderDetail,
            string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker makes 1 coffee with no sugar - and therefore no stick", customerMessage);
        }

        [Theory]
        [InlineData("C:0:0", "0.7")]
        [InlineData("C:0:", "0.7")]
        public void ShouldGenerateCorrectMessage_WhenOrderHasCoffee_WithoutSugar_WithOverPayment(string orderDetail,
            string paymentAmount)
        {
            //Arrange
            string[] updates = {orderDetail, paymentAmount};

            var order =
                _orderCreator
                    .BuildOrderCreator(updates)
                    .CreateOrder();

            //Act
            var customerMessage = _customerMessageGenerator.GenerateCustomerMessage(order);

            //Assert
            Assert.Equal("Drink maker makes 1 coffee with no sugar - and therefore no stick, and 0.1 euros as change",
                customerMessage);
        }
    }
}