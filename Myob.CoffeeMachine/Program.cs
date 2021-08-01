using System;
using Myob.CoffeeMachine;

namespace Myob.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineDomain.CoffeeMachine coffeeMachine = new CoffeeMachineDomain.CoffeeMachine(new CoffeeMachineDomain.CoffeeMachineConsolePresenter());
            Console.WriteLine("What drink do you want to order?");
            string userInput = Console.ReadLine();
            coffeeMachine.MakeDrink(userInput);
        }
    }
}