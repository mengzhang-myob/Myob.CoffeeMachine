namespace Myob.CoffeeMachineDomain
{
    public class OrderHistoryManager
    {
        private readonly OrderHistory _orderHistory = new OrderHistory();

        public void SaveOrder(Order order)
        {
            switch (order.DrinkType)
            {
                case "coffee":
                    _orderHistory.CoffeeSales++;
                    _orderHistory.Profit += order.ActualPrice;
                    break;
                case "tea":
                    _orderHistory.TeaSales++;
                    _orderHistory.Profit += order.ActualPrice;
                    break;
                case "chocolate":
                    _orderHistory.ChocolateSales++;
                    _orderHistory.Profit += order.ActualPrice;
                    break;
                case "orange juice":
                    _orderHistory.OrangeJuiceSales++;
                    _orderHistory.Profit += order.ActualPrice;
                    break;
            }
        }

        public OrderHistory RetrieveOrderHistory()
        {
            return _orderHistory;
        }
    }
}