using System;
using System.Collections.Generic;

namespace Myob.CoffeeMachineDomain
{
    public class OrderCreator
    {
        private readonly Dictionary<string, decimal> _drinkPriceList = new Dictionary<string, decimal>
        {
            {DrinkTypeEnum.tea.ToString(), 0.4m},
            {DrinkTypeEnum.chocolate.ToString(), 0.5m},
            {DrinkTypeEnum.coffee.ToString(), 0.6m},
            {DrinkTypeEnum.orange + " juice", 0.6m}
        };

        private readonly Dictionary<string, string> _drinks = new Dictionary<string, string>
        {
            {"T", DrinkTypeEnum.tea.ToString()},
            {"H", DrinkTypeEnum.chocolate.ToString()},
            {"C", DrinkTypeEnum.coffee.ToString()},
            {"O", DrinkTypeEnum.orange + " juice"}
        };

        private decimal _actualPrice;
        private decimal _amountOfChange;
        private int _amountOfSugar;
        private string _drinkType;
        private bool _isExtraHot;
        private decimal _paymentAmount;

        public Order CreateOrder()
        {
            var order = new Order
            (
                _drinkType,
                _actualPrice,
                _paymentAmount,
                _amountOfChange,
                _amountOfSugar,
                _isExtraHot
            );
            return order;
        }

        public OrderCreator BuildOrderCreator(string[] userInput)
        {
            if (IsOrderValid(userInput))
            {
                if (IsPaymentDetailValid(userInput[1]))
                {
                    SetOrderDetail(userInput);
                    SetPaymentDetails(userInput[1]);
                    return this;
                }

                throw new ArgumentException("Wrong format, your payment detail should be a decimal value");
            }

            throw new ArgumentException("This Order is in the wrong format");
        }

        //command query separation
        //command - changing things - updating state , performing action
        //query - return a value

        //get the answer whether it's validate
        //return type is confusing
        //assigning state

        private void SetOrderDetail(string[] userInput)
        {
            var orderDetail = userInput[0].Split(":");
            if (orderDetail.Length == 3)
            {
                if (IsExtraHot(orderDetail))
                {
                    SetOrderDetailForExtraHotDrink(orderDetail);
                    return;
                }

                if (CheckIfDrinkTypeExists(orderDetail[0]))
                {
                    if (orderDetail[1] == "")
                    {
                        _amountOfSugar = 0;
                        _drinkType = _drinks[orderDetail[0]];
                        _isExtraHot = false;
                        return;
                    }

                    if (int.TryParse(orderDetail[1], out var sugarWithoutExtraHot))
                    {
                        if (IsJuice(orderDetail[0]) && sugarWithoutExtraHot != 0)
                            throw new ArgumentException("Orange juice cannot have extra sugar");
                        _amountOfSugar = sugarWithoutExtraHot;
                        _drinkType = _drinks[orderDetail[0]];
                        _isExtraHot = false;
                        return;
                    }

                    throw new ArgumentException(
                        "Sorry, the amount of sugar you entered is invalid");
                }

                throw new ArgumentException(
                    "Sorry, we don't have the drink you ordered");
            }

            throw new ArgumentException(
                "Please ensure the format of your order is 'Drink type:Amount of sugar:Number of stick' or 'Drink type::'");
        }


        private void SetOrderDetailForExtraHotDrink(string[] orderDetail)
        {
            var drinkTypeInput = orderDetail[0].Remove(orderDetail[0].Length - 1, 1);
            if (CheckIfDrinkTypeExists(drinkTypeInput))
            {
                if (orderDetail[1] == "")
                {
                    _amountOfSugar = 0;
                    _drinkType = _drinks[drinkTypeInput];
                    _isExtraHot = true;
                    return;
                }

                if (int.TryParse(orderDetail[1], out var sugarWithExtraHot))
                {
                    if (IsJuice(drinkTypeInput)) throw new ArgumentException("Orange juice cannot be made extra hot");

                    _amountOfSugar = sugarWithExtraHot;
                    _drinkType = _drinks[drinkTypeInput];
                    _isExtraHot = true;
                    return;
                }
            }

            throw new ArgumentException(
                "Your order detail does not have the information we want, please check the drink type or the amount of sugar");
        }

        private bool CheckIfDrinkTypeExists(string drinkTypeInput)
        {
            return _drinks.ContainsKey(drinkTypeInput);
        }

        private void SetPaymentDetails(string payment)
        {
            _paymentAmount = Convert.ToDecimal(payment);
            _actualPrice = _drinkPriceList[_drinkType];
            if (_paymentAmount >= _actualPrice)
            {
                _amountOfChange = _paymentAmount - _actualPrice;
                return;
            }

            throw new ArgumentException("You did not pay enough money");
        }

        private static bool IsExtraHot(string[] orderDetail)
        {
            return orderDetail[0].EndsWith("h");
        }

        private bool IsPaymentDetailValid(string payment)
        {
            return decimal.TryParse(payment, out var result);
        }

        private bool IsOrderValid(string[] userInput)
        {
            return userInput.Length == 2;
        }

        private bool IsJuice(string userInput)
        {
            return _drinks[userInput].EndsWith("juice");
        }

        private enum DrinkTypeEnum
        {
            tea,
            chocolate,
            coffee,
            orange
        }
    }
}