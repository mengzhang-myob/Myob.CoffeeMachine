using System;

namespace Myob.CoffeeMachineDomain
{
    public interface ICoffeeMachinePresenter
    {
            void PresentCustomerMessage(Order order);
    }
}