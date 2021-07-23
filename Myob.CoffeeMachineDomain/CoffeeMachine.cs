using System;
using System.Globalization;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachine
    {
        public class CoffeeMachineOutput : ICoffeeMachineOutput
        {
            public string OutPutText { get; set; }
            public void Print()
            {
                Console.WriteLine(OutPutText);
            }
        }
        public void MakeDrink()
        {
            Console.WriteLine("Please enter the drink you want to make");
            var userInput = Console.ReadLine();
            try
            {
                Order order = new Order();
                CoffeeMachineOutput coffeeMachineOutput = new CoffeeMachineOutput();
                string [] orderDetails = userInput.Split(":");
                order.SetDrinkType(orderDetails[0]);
                order.SetNumberOfSugar(orderDetails[1]);
                order.SetStick();
                if (order.DrinkType == "Unknown" || order.DrinkType == null)
                {
                    coffeeMachineOutput.OutPutText = "Sorry we don't know this drink";
                    coffeeMachineOutput.Print();
                    return;
                }

                if (order.Sugar >= 0)
                {
                    if (order.Sugar == 0)
                    {
                        coffeeMachineOutput.OutPutText = $"Drink maker makes 1 {order.DrinkType} with no sugar - and therefore no stick";
                        coffeeMachineOutput.Print();
                        return;
                    }

                    if (order.Sugar == 1)
                    {
                        coffeeMachineOutput.OutPutText = $"Drink maker makes 1 {order.DrinkType} with 1 sugar and a stick";
                        coffeeMachineOutput.Print();
                        return;
                    }
                    coffeeMachineOutput.OutPutText = $"Drink maker makes 1 {order.DrinkType} with {order.Sugar} sugars and a stick";
                    coffeeMachineOutput.Print();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw; 
            }
                
        }
    }
}