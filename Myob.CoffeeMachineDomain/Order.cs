using System;

namespace Myob.CoffeeMachineDomain
{
    public class Order
    {
        public string DrinkType { get; private set; }
        /*TODO make it enum*/
        public decimal PaymentAmount { get; private set; }
        public decimal ActualPrice { get; private set;  }
        public decimal AmountOfChange { get; private set; }
        private int _sugar;
        public void SetDrinkType(string inputDrinkType)
        {
            try
            {
                if (CoffeeMachineValidator.IsDrinkTypeValid(inputDrinkType))
                {
                    DrinkType = inputDrinkType == "T" ? "Tea" : inputDrinkType == "C" ? "Coffee" : "Chocolate";
                    return;
                }

                DrinkType = "Unknown";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public int AmountOfSugar()
        {
            return _sugar;
        }
        public bool HasNoSugar()
        {
            return _sugar == 0;
        }
        
        public bool HasMoreThanSetAmountOfSugar ()
        {
            return _sugar > 1;
        }
        
        public void SetNumberOfSugar(string inputSugar)
        {
            try
            {
                if (!int.TryParse(inputSugar, out int output) || DrinkType == "Unknown")
                {
                    _sugar = 0;
                }

                _sugar = output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void SetPaymentAmount(string inputMoney)
        {
            try
            {
                if (!decimal.TryParse(inputMoney, out decimal output) || DrinkType == "Unknown")
                {
                    PaymentAmount = 0;
                }
                PaymentAmount = output;
                SetActualPriceAndAmountOfChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SetActualPriceAndAmountOfChange()
        {
            if (DrinkType == "Tea")
            {
                ActualPrice = (decimal) 0.4;
                AmountOfChange = PaymentAmount - ActualPrice;
            }
            else if (DrinkType == "Chocolate")
            {
                ActualPrice = (decimal) 0.5;
                AmountOfChange = PaymentAmount - ActualPrice;
            }
            else if (DrinkType == "Coffee")
            {
                ActualPrice = (decimal) 0.6;
                AmountOfChange = PaymentAmount - ActualPrice;
            }
            else
            {
                ActualPrice = 0;
                AmountOfChange = 0;
            }
        }
        
    }
}