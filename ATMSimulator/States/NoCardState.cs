using ATMSimulator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator.State
{
    public class NoCardState : IATMachine
    {

        public decimal GetCardBalance()
        {
            throw new NotImplementedException();
        }

        public void InsertCard(string cardNumber)
        {
            Console.WriteLine("Debit Card Inserted");
        }

        public void ReturnCard()
        {
            Console.WriteLine(" No Debit Card Inside ATM");
        }

        public Money WithdrawMoney(int amount)
        {
            Console.WriteLine("No Debit Card Inside ATM");
            return new Money { Amount = 0, Notes = new Dictionary<PaperNote, int>() { { new PaperNote { Amount = 0, Name = "€" }, 0 } } };
            
        }
    }
}
