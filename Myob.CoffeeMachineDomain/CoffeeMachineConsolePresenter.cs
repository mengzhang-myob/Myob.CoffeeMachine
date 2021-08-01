using System;
using System.Linq;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachineConsolePresenter : ICoffeeMachinePresenter
    {
        public string OutputText { get; set; }
        public string InputText { get; set; }
        public void WriteLine()
        {
            Console.WriteLine(OutputText);
        }

        public void OutputForUnknownDrinkType()
        {
            OutputText = "Sorry we don't know this drink";
            Console.WriteLine(OutputText);
        }

        public void OutputForOrdersWithoutPayment()
        {
            OutputText = "Sorry, you need to pay for your order";
            Console.WriteLine(OutputText);
        }

        public void OutputForUnderPaidOrders()
        {
            OutputText = "Sorry you didn't pay enough money";
            Console.WriteLine(OutputText);
        }
        public void SetOutPutForValidDrinkTypesWithValidPayment(Order order)
        {
            if (order.HasNoSugar())
            {
                OutputText = $"Drink maker makes 1 {order.DrinkType} with no sugar - and therefore no stick";
                if (CoffeeMachineValidator.IsMoneyOverPaid(order))
                {
                    SetOutPutForValidDrinkTypesWithOverPayment(order);
                }
            }

            else if (order.HasMoreThanSetAmountOfSugar())
            {
                OutputText = $"Drink maker makes 1 {order.DrinkType} with {order.AmountOfSugar()} sugars and a stick";
                if (CoffeeMachineValidator.IsMoneyOverPaid(order))
                {
                    SetOutPutForValidDrinkTypesWithOverPayment(order);
                }
            }
            else
            {
                OutputText = $"Drink maker makes 1 {order.DrinkType} with 1 sugar and a stick";
                if (CoffeeMachineValidator.IsMoneyOverPaid(order))
                {
                    SetOutPutForValidDrinkTypesWithOverPayment(order);
                }
            }


        }

        public void SetOutPutForValidDrinkTypesWithOverPayment(Order order)
        {
            OutputText += $", with {order.AmountOfChange} euros of change";
        }
    }
}