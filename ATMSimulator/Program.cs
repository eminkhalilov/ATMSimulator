using ATMSimulator.Abstracts;
using ATMSimulator.Enums;
using ATMSimulator.State;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ATMSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

     begin:
            var anyAtm = new AnyATM();

            Console.WriteLine("*** Welcome to Any Bank ATM ***");
            Console.WriteLine("Please, insert your card");

            var cardNumber = Console.ReadLine();
            anyAtm.InsertCard(cardNumber);

            Console.WriteLine($"Your balance: {anyAtm.GetCardBalance()}");
            Console.WriteLine("        Choose Menu         ");
            Console.WriteLine("    Withdraw Money : 1    ");
            Console.WriteLine("    Get Balance : 2       ");
            Console.WriteLine("    Return Card : 3       ");

            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case (int)OptionMenu.WithDraw:
                    Console.Write("Enter amount of money:");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    anyAtm.WithdrawMoney(amount);
                    goto case (int)OptionMenu.ReturnCard;

                case (int)OptionMenu.CardBalance: anyAtm.GetCardBalance();
                    Console.WriteLine($"Balance: {anyAtm.GetCardBalance()}");
                    anyAtm.ReturnCard();
                    goto begin;

                case (int)OptionMenu.ReturnCard: anyAtm.ReturnCard(); goto begin;

                default:
                    goto begin;
            }
          
        }
    }
}
