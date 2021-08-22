using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Myob.CoffeeMachineDomain
{
    public class BeverageQuantityChecker : IBeverageQuantityChecker
    {
        public List<string> _soldOutDrinkTypeList = new List<string>();
        private int _stockThreshold = 10;
        public bool CheckIfBeverageSoldOut(OrderHistory orderHistory)
        {
            if (orderHistory.ChocolateSales > _stockThreshold)
            {
                _soldOutDrinkTypeList.Add("chocolate");
            }
            if (orderHistory.OrangeJuiceSales > _stockThreshold)
            {
                _soldOutDrinkTypeList.Add("orange juice");
            }
            if (orderHistory.TeaSales > _stockThreshold)
            {
                _soldOutDrinkTypeList.Add("tea");
            }
            if (orderHistory.CoffeeSales > _stockThreshold)
            {
                _soldOutDrinkTypeList.Add("coffee");
            }

            return _soldOutDrinkTypeList.Any();
        }
    }
}