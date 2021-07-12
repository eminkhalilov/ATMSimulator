using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator.Abstracts
{
    public interface IATMachine
    {

        /// <summary>Insert bank card into ATM machine</summary>
                /// <param name="cardNumber">Card number</param>
        void InsertCard(string cardNumber);

        /// <summary>Retrieves the balance available on the card</summary>
        decimal GetCardBalance();

        ///<summary>Withdraw money from ATM.</summary>
                ///<paramname="amount">Amount of money to withdraw.</param>
        Money WithdrawMoney(int amount);

        ///<summary>Returns card back to client.</summary>
        void ReturnCard();

    }
}
