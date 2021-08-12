using System;
using System.Linq;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachineConsolePresenter : ICoffeeMachinePresenter
    {
        public void PresentCustomerMessage(Order order)
        {
            var customerMessageGenerator = new CustomerMessageGenerator();
            Console.WriteLine(customerMessageGenerator.GenerateCustomerMessage(order));
        }
    }
}