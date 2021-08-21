using System;
using Myob.CoffeeMachineDomain;
using Xunit;

namespace Myob.CoffeeMachineUnitTests
{
    public class EmailNotifierTests
    {
        private EmailNotifier _emailNotifier = new EmailNotifier();
        [Fact]
        public void ShouldGenerateCorrectEmailMessage_WhenSingleDrinkIsSoldOut()
        {
            //Arrange
            string[] soldOutDrinkTypeList = {"orange juice"};
            
            //Act
            _emailNotifier.SetEmailMessage(soldOutDrinkTypeList);
            
            //Assert
            Assert.Equal($"Sorry, the drink(s) below are are sold out:" +
                         $"{Environment.NewLine} orange juice", _emailNotifier.EmailMessage);
        }
        [Fact]
        public void ShouldGenerateCorrectEmailMessage_WhenMultipleDrinksAreSoldOut()
        {
            //Arrange
            string[] soldOutDrinkTypeList = {"orange juice", "tea", "coffee"};
            
            //Act
            _emailNotifier.SetEmailMessage(soldOutDrinkTypeList);
            
            //Assert
            Assert.Equal("Sorry, the drink(s) below are are sold out:" +
                         $"{Environment.NewLine} orange juice" +
                         $"{Environment.NewLine} tea" +
                         $"{Environment.NewLine} coffee", _emailNotifier.EmailMessage);
        }
        
    }
}