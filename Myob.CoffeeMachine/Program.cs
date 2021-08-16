using System;
using Myob.CoffeeMachine;

namespace Myob.CoffeeMachine
{
    class Program
    {
        static void Main()
        {
            CoffeeMachineDomain.CoffeeMachine coffeeMachine = new CoffeeMachineDomain.CoffeeMachine(new CoffeeMachineDomain.CoffeeMachineConsolePresenter());
            StartConsoleWorkFlowForNewOrders(coffeeMachine);
        }

        private static void StartConsoleWorkFlowForMoreOptions(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
            Console.WriteLine("Do you want to order more, if so then press Y? Alternatively, press R to generate report");
            string userResponse = Console.ReadLine();
            if (userResponse == "Y" || userResponse == "y")
            {
                StartConsoleWorkFlowForNewOrders(coffeeMachine);
            }
            else if(userResponse == "R" || userResponse == "r")
            {
                StartConsoleWorkFlowForPrintingHistory(coffeeMachine);
            }
        }

        private static void StartConsoleWorkFlowForNewOrders(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
            Console.WriteLine("What drink do you want to order?");
            string userInput = Console.ReadLine();
            coffeeMachine.MakeDrink(userInput);
            StartConsoleWorkFlowForMoreOptions(coffeeMachine);
        }
        private static void StartConsoleWorkFlowForPrintingHistory(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
           coffeeMachine.PrintOrderHistory();
        }
    }
}