using System;

namespace Myob.CoffeeMachineDomain
{
    public class Order
    {
        public string DrinkType { get; set; }
        public int Sugar { get; set; }
        public bool NeedStick { get; set; }
        public void SetDrinkType(string inputDrink)
        {
            try
            {
                if (inputDrink == "T")
                {
                    DrinkType = "tea";
                }
                else if (inputDrink == "H")
                {
                    DrinkType = "tea";
                }
                else if (inputDrink == "C")
                {
                    DrinkType = "coffee";
                }
            }
            catch (Exception e)
            {
                DrinkType = "Unknown";
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetNumberOfSugar(string inputSugar)
        {
            try
            {
                if (int.TryParse(inputSugar, out int output) && DrinkType == "Unknown")
                {
                    Sugar = 0;
                }

                Sugar = output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void SetStick()
        {
            try
            {
                if (Sugar >= 1)
                {
                    NeedStick = true;
                }

                NeedStick = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}