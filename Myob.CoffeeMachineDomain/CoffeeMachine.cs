using System;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachine
    {
        private readonly CoffeeMachineConsolePresenter coffeeMachineConsolePresenter;
        private readonly OrderHistoryManager orderHistoryManager = new OrderHistoryManager();

        public CoffeeMachine(CoffeeMachineConsolePresenter consolePresenter)
        {
            coffeeMachineConsolePresenter = consolePresenter;
        }

        public void MakeDrink(string originUserInout)
        {
            try
            {
                var userInput = originUserInout.Split(",");
                var orderCreator = new OrderCreator();
                var order = orderCreator.BuildOrderCreator(userInput).CreateOrder();
                coffeeMachineConsolePresenter.PresentCustomerMessage(order);
                orderHistoryManager.SaveOrder(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PrintOrderHistory()
        {
            try
            {
                coffeeMachineConsolePresenter.PresentOrderHistory(orderHistoryManager.RetrieveOrderHistory());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}