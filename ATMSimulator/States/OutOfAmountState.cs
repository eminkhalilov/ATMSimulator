using ATMSimulator.Abstracts;
using ATMSimulator.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator.States
{
    public class OutOfAmountState : IATMachine
    {
        IATMachine _state;
        public OutOfAmountState()
        {
            Console.WriteLine("ATM out of money!");
        }
        public decimal GetCardBalance()
        {
            throw new NotImplementedException();
        }

        public void InsertCard(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public void ReturnCard()
        {
            _state = new NoCardState();
        }

        public Money WithdrawMoney(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
