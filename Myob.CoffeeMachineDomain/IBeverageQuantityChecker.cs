using System.Linq;

namespace Myob.CoffeeMachineDomain
{
    public class IBeverageQuantityChecker
    {
        public string[] _soldOutDrinkTypeList { get; set; }
        private int _stockThreshold = 10;
        bool IsBeverageSoldOut(OrderHistory orderHistory)
        {
            if (orderHistory.ChocolateSales >= _stockThreshold)
            {
                _soldOutDrinkTypeList.Append("chocolate");
                return true;
            }
            if (orderHistory.OrangeJuiceSales >= _stockThreshold)
            {
                _soldOutDrinkTypeList.Append("orange juice");
                return true;
            }
            if (orderHistory.TeaSales >= _stockThreshold)
            {
                _soldOutDrinkTypeList.Append("tea");
                return true;
            }
            if (orderHistory.CoffeeSales >= _stockThreshold)
            {
                _soldOutDrinkTypeList.Append("coffee");
                return true;
            }

            return false;
        }
    }
}