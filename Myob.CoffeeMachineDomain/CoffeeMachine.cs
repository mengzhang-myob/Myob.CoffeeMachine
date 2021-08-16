﻿using System;
using System.Globalization;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachine
    {
        private CoffeeMachineConsolePresenter coffeeMachineConsolePresenter;

        public CoffeeMachine (CoffeeMachineConsolePresenter consolePresenter)
        {
            coffeeMachineConsolePresenter = consolePresenter;
        }
        public void MakeDrink(string originUserInout)
        {
            try
            {
                var userInput = originUserInout.Split(",");
                OrderCreator orderCreator = new OrderCreator();
                Order order = orderCreator.BuildOrderCreator(userInput).CreateOrder();
                coffeeMachineConsolePresenter.PresentCustomerMessage(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                
        }

        public void PrintOrderHistory()
        {
            try
            {
                coffeeMachineConsolePresenter.PresentOrderHistory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }

}