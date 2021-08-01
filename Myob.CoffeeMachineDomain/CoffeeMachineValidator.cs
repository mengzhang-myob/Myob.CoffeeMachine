using System;

namespace Myob.CoffeeMachineDomain
{
    public class CoffeeMachineValidator
    {
        public static bool IsDrinkTypeValid(string drinkType)
        {
            try
            {
                return (drinkType == "T" || drinkType == "C" || drinkType == "H");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static bool IsMoneyCorrectlyPaid(Order order)
        {
            try
            {
                return order.AmountOfChange == 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool IsMoneyOverPaid(Order order)
        {
            try
            {
                return order.ActualPrice < order.PaymentAmount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        public static bool IsMoneyUnderPaid(Order order)
        {
            try
            {
                var test = IsMoneyCorrectlyPaid(order) || IsMoneyOverPaid(order);
                if (test == true)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}