using ATMSimulator.Abstracts;
using ATMSimulator.State;
using ATMSimulator.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public class AnyATM : IATMachine
    {
        public string Manufacturer => "Any Manufacturer LLC";
        public string SerialNumber => "3211-2342-5567-8675";
        public IATMachine _state;
        public Money _atmBalance =
            new Money
            {
                Amount = 1000,
                Notes = new Dictionary<PaperNote, int>() 
                {
                    { new PaperNote { Amount = 5, Name = "€" }, 20 },
                    { new PaperNote { Amount = 10, Name = "€" }, 10 },
                    { new PaperNote { Amount = 20, Name = "€" }, 10 },
                    { new PaperNote { Amount = 50, Name = "€" }, 12 }
                }
            };
        public string _cardNumber { get; set; }

        public AnyATM()
        {
            _state = new NoCardState();

            if (_atmBalance.Amount < 0 )
            {
                _state = new OutOfAmountState();
            }
        }

        public decimal GetCardBalance()
        {
            return _state.GetCardBalance();
        }

        public void InsertCard(string cardNumber)
        {
            if (_state is NoCardState)
            {
                _state = new HasCardState(this);
                _cardNumber = cardNumber;
                Console.WriteLine("Your Card Inserted Successfully!");
            }
        }

        public void ReturnCard()
        {
            _state.ReturnCard();

            if (_state is HasCardState)
            {
                _state = new NoCardState();
            }
        }

        public Money WithdrawMoney(int amount)
        {
            if (_state is HasCardState)
            {
                _state.WithdrawMoney(amount);
            }
            return new Money();
        }

        public void SetATMSate(IATMachine newState)
        {
            _state = newState;
        }

    }
}
