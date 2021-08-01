using System;
using System.Globalization;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachine
    {
        public CoffeeMachineConsolePresenter coffeeMachineConsolePresenter;

        public CoffeeMachine (CoffeeMachineConsolePresenter consolePresenter)
        {
            coffeeMachineConsolePresenter = consolePresenter;
        }
        public void MakeDrink(string input)
        {
            coffeeMachineConsolePresenter.InputText = input;
            try
            {
                Order order = new Order();
                string [] orderDetailsAndPayment = coffeeMachineConsolePresenter.InputText.Split(",");
                /*var messageForCustomer = "default message";*/
                GeneratePresenterOutput(orderDetailsAndPayment, order);
/*xx.verify*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw; 
            }
                
        }

        private void GeneratePresenterOutput(string[] orderDetailsAndPayment, Order order)
        {
            if (CheckIfInputHasOrderAndPayment(orderDetailsAndPayment))
            {
                var paymentAmount = orderDetailsAndPayment[1];
                string[] orderDetails = orderDetailsAndPayment[0].Split(":");
                order.SetDrinkType(orderDetails[0]);
                order.SetNumberOfSugar(orderDetails[1]);
                order.SetPaymentAmount(paymentAmount);
                if (!IsInvalidDrink(order))
                {
                    if (CoffeeMachineValidator.IsMoneyUnderPaid(order))
                    {
                        coffeeMachineConsolePresenter.OutputForUnderPaidOrders();
                        return;
                    }

                    coffeeMachineConsolePresenter.SetOutPutForValidDrinkTypesWithValidPayment(order);
                    coffeeMachineConsolePresenter.WriteLine();
                }
            }
        }

        private bool IsInvalidDrink(Order order)
        {
            return order.DrinkType == "Unknown" || order.DrinkType == null;
        }
        private bool CheckIfInputHasOrderAndPayment(string [] input)
        {
            return input.Length == 2;
        }
    }
    /*TODO: Create new interface in a separate file unless it's related to Data model*/
    /*TODO: Get to know DTO (data transfer object)*/

}