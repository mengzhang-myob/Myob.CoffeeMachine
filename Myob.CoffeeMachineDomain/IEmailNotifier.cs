using System;
using System.Linq;

namespace Myob.CoffeeMachineDomain
{
    public interface IEmailNotifier
    {
        string EmailMessage { get; set; }

        void SetEmailMessage(string[] _soldOutDrinkTypeList)
        {
                           
        }
    }
}