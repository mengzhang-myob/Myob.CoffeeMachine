using System;
using Myob.CoffeeMachine;

namespace Myob.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineDomain.CoffeeMachine coffeeMachine = new CoffeeMachineDomain.CoffeeMachine();
            coffeeMachine.MakeDrink();
        }
    }
}