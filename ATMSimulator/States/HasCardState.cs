using ATMSimulator.Abstracts;
using ATMSimulator.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator.State
{
    public class HasCardState : IATMachine
    {
        public decimal cardBalance  = 500;
        public AnyATM _anyATM;
        public IATMachine _state;

        public HasCardState(AnyATM anyATM)
        {
            _anyATM = anyATM;
        }
        public decimal GetCardBalance()
        {
            return cardBalance;
        }

        public void InsertCard(string cardNumber)
        {
            Console.WriteLine("Debit card is already there, so can not insert debit card");
        }

        public void ReturnCard()
        {
            Console.WriteLine("Debit card ejected successfully");
        }

        public Money WithdrawMoney(int amount)
        {
            if (amount > _anyATM._atmBalance.Amount || amount > cardBalance)
            {
               _state = new OutOfAmountState();
                _anyATM.ReturnCard();
            }

           var isValidNote = _anyATM._atmBalance.Notes.ContainsKey(new PaperNote { Amount = amount, Name= "€" });
            if (!isValidNote)
            {
                Console.WriteLine("Machine allows to withdraw: 5€, 10€, 20€, 50€ paper notes");
            }

            _anyATM._atmBalance.Amount = _anyATM._atmBalance.Amount - amount;
            cardBalance = cardBalance - amount;

            return new Money { Amount = amount, Notes = new Dictionary<PaperNote, int>() { { new PaperNote { Amount = amount, Name = "€" }, 0 } } }; ;
        }
    }
}
