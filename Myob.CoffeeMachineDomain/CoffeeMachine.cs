using System;
using System.Globalization;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachine
    {
        public CoffeeMachineConsolePresenter coffeeMachineConsolePresenter;

        public CoffeeMachine (CoffeeMachineConsolePresenter consolePresenter)
        {
            coffeeMachineConsolePresenter = consolePresenter;
        }
        public void MakeDrink(string originUserInout)
        {
            try
            {
                var userInput = originUserInout.Split(",");
                OrderCreator orderCreator = new OrderCreator();
                orderCreator.BuildOrderCreator(userInput);
                Order order = orderCreator.CreateOrder();
                coffeeMachineConsolePresenter.PresentCustomerMessage(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                
        }
    }

}