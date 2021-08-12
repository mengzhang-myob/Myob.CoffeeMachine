using System;

namespace Myob.CoffeeMachineDomain
{
    public class Order
    {
        public string DrinkType { set; get; }
        public decimal ActualPrice { set; get; }
        public decimal PaymentAmount { set; get; }
        public decimal AmountOfChange { set; get; }
        public int AmountOfSugar { set; get; }
        public bool IsExtraHot { set; get; }
        public Order (string drinkType, decimal actualPrice, decimal paymentAmount, decimal amountOfChange, int amountOfSugar, bool isExtraHot)
        {
            DrinkType = drinkType;
            ActualPrice = actualPrice;
            PaymentAmount = paymentAmount;
            AmountOfChange = amountOfChange;
            AmountOfSugar = amountOfSugar;
            IsExtraHot = isExtraHot;
        }
    }
}