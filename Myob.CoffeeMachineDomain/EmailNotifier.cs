using System;
using System.Linq;

namespace Myob.CoffeeMachineDomain
{
    public class EmailNotifier : IEmailNotifier
    {
        public string EmailMessage { get; set; } = "Sorry, the drink(s) below are are sold out:";
        public void SetEmailMessage(string[] _soldOutDrinkTypeList)
        {
            foreach (var d in _soldOutDrinkTypeList)
            {
                EmailMessage +=$"{Environment.NewLine} {d}";
            }
                           
        }
    }
}