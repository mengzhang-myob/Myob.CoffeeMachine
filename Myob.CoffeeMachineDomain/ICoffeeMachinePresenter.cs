using System;

namespace Myob.CoffeeMachineDomain
{
    public interface ICoffeeMachinePresenter
    {
            void WriteLine();
            void OutputForUnknownDrinkType();
            void OutputForOrdersWithoutPayment();
            void OutputForUnderPaidOrders();
            void SetOutPutForValidDrinkTypesWithValidPayment(Order order);
            void SetOutPutForValidDrinkTypesWithOverPayment(Order order);
    }
}