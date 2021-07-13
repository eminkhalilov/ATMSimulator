using ATMSimulator.State;
using ATMSimulator.States;
using System;
using System.Collections.Generic;
using Xunit;

namespace ATMSimulator.Tests
{
    public class AtmUnitTest
    {
        [Fact]
        public void Cash_WithDrawal_NoCardState()
        {
           var noCardState =  new NoCardState();
            var actual = noCardState.WithdrawMoney(10); 
            var expected = new Money { Amount = 0, Notes = new Dictionary<PaperNote, int>() { { new PaperNote { Amount = 0, Name = "€" }, 0 } } };
            Assert.Equal(expected.Amount,  actual.Amount);
            Assert.Equal(expected.Notes,  actual.Notes);
        }

        [Fact]
        public void Cash_WithDrawal_HasCardState()
        {
            var hasCardState = new HasCardState(new AnyATM());
            var amount = 10;
            var actual = hasCardState.WithdrawMoney(amount);
            var expected = new Money { Amount = amount, Notes = new Dictionary<PaperNote, int>() { { new PaperNote { Amount = amount, Name = "€" }, 0 } } };
            Assert.Equal(expected.Amount, actual.Amount);
            Assert.Equal(expected.Notes, actual.Notes);
        }

        [Fact]
        public void ReturnCard_WithDrawal()
        {
            var noCardState = new NoCardState();
            var actual = noCardState.WithdrawMoney(10);
            var expected = new Money { Amount = 0, Notes = new Dictionary<PaperNote, int>() { { new PaperNote { Amount = 0, Name = "€" }, 0 } } };
            Assert.Equal(expected.Amount, actual.Amount);
            Assert.Equal(expected.Notes, actual.Notes);
        }
    }
}
