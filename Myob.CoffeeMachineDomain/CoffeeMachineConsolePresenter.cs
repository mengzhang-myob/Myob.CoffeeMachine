using System;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachineConsolePresenter : ICoffeeMachinePresenter
    {
        public void PresentCustomerMessage(Order order)
        {
            var customerMessageGenerator = new CustomerMessageGenerator();
            Console.WriteLine(customerMessageGenerator.GenerateCustomerMessage(order));
        }

        public void PresentOrderHistory(OrderHistory orderHistory)
        {
            var customerMessageGenerator = new CustomerMessageGenerator();
            Console.WriteLine(customerMessageGenerator.GenerateCustomerMessageForOrderHistory(orderHistory));
        }
    }
}