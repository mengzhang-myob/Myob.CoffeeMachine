using System.Runtime.Intrinsics.X86;

namespace Myob.CoffeeMachineDomain
{
    public class CustomerMessageGenerator
    {
        private readonly string _defaultDrinkMakerMessageForNonJuiceDrink = "Drink maker makes 1";

        private readonly string _defaultDrinkMakerMessageForExtraHotNonJuiceDrink =
            "Drink maker will make an extra hot";

        private readonly string _defaultDrinkMakerMessageForJuice = "Drink maker will make one";

        private readonly string _defaultSugarMessageForDrinkWithOneSugar = " with 1 sugar and a stick";

        private readonly string _defaultSugarMessageForNonJuiceDrinkWithoutSugar =
            " with no sugar - and therefore no stick";

        private readonly string _defaultSugarMessageForExtraHotNonJuiceDrinkWithoutSugar = " with no sugar";

        private string GenerateSugarMessage(Order order)
        {
            if (order.AmountOfSugar > 1)
            {
                return $" with {order.AmountOfSugar} sugars and a stick";
            }

            if (order.AmountOfSugar == 1)
            {
                return _defaultSugarMessageForDrinkWithOneSugar;
            }

            if (order.DrinkType == "orange juice")
            {
                return "";
            }

            if (order.IsExtraHot)
            {
                return _defaultSugarMessageForExtraHotNonJuiceDrinkWithoutSugar;
            }
            
            return _defaultSugarMessageForNonJuiceDrinkWithoutSugar;
        }

        private string GenerateDrinkMakerMessage(Order order)
        {
            if (order.IsExtraHot)
            {
                return $"{_defaultDrinkMakerMessageForExtraHotNonJuiceDrink} {order.DrinkType}";
            }

            if (order.DrinkType == "orange juice")
            {
                return $"{_defaultDrinkMakerMessageForJuice} {order.DrinkType}";
            }
            return $"{_defaultDrinkMakerMessageForNonJuiceDrink} {order.DrinkType}";
        }
        
        private string GenerateAmountOfChangeMessage(Order order)
        {
            if (order.AmountOfChange == 0)
            {
                return "";
            }

            return $", and {order.AmountOfChange} euros as change";
        }
        
        public string GenerateCustomerMessage(Order order)
        {
            return $"{GenerateDrinkMakerMessage(order)}{GenerateSugarMessage(order)}{GenerateAmountOfChangeMessage(order)}";
        }
    }
}