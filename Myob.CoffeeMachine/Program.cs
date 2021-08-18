using System;
using Myob.CoffeeMachineDomain;

namespace Myob.CoffeeMachine
{
    internal class Program
    {
        private static void Main()
        {
            var coffeeMachine = new CoffeeMachineDomain.CoffeeMachine(new CoffeeMachineConsolePresenter());
            StartConsoleWorkFlowForNewOrders(coffeeMachine);
        }

        private static void StartConsoleWorkFlowForMoreOptions(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
            Console.WriteLine(
                "Do you want to order more, if so then press Y/y? Alternatively, press R/r to generate report");
            var userResponse = Console.ReadLine();
            if (userResponse == "Y" || userResponse == "y")
                StartConsoleWorkFlowForNewOrders(coffeeMachine);
            else if (userResponse == "R" || userResponse == "r") StartConsoleWorkFlowForPrintingHistory(coffeeMachine);
        }

        private static void StartConsoleWorkFlowForNewOrders(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
            Console.WriteLine("What drink do you want to order?");
            var userInput = Console.ReadLine();
            coffeeMachine.MakeDrink(userInput);
            StartConsoleWorkFlowForMoreOptions(coffeeMachine);
        }

        private static void StartConsoleWorkFlowForPrintingHistory(CoffeeMachineDomain.CoffeeMachine coffeeMachine)
        {
            coffeeMachine.PrintOrderHistory();
        }
    }
}