using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_bank_
{
    abstract class Account : IAccountInfo
    {
        public abstract string Number { get; }
        public decimal Balance { get; set; }

        public IClientInfo Client { get; set; }

        private TransitionHistory _transitionHistory = new TransitionHistory();
        public TransitionHistory transitionHistory => _transitionHistory;

        public void Enrollment(decimal money)
        {
            decimal tmp = Math.Round(money, 2);
            if (money % tmp != 0)
                throw new Exception("\n---\nCent's can't be > 99\n---");

            Balance += money;

            transitionHistory.transitions.Add(new TransitionInfo(TransitionType.Deposit, "bank", Number, money));

            Console.WriteLine(this);
        }

        public void Withdraw(decimal money)
        {
            decimal tmp = Math.Round(money, 2);
            if (money % tmp != 0)
                throw new Exception("\n---\nCent's can't be > 99\n---");

            if (Balance - money < 0) throw new Exception("\n---\nNot enough money for Withdraw\n---");

            Balance -= money;

            transitionHistory.transitions.Add(new TransitionInfo(TransitionType.Withdraw, Number, "person", money));

            Console.WriteLine(this);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Account)) return false;
            Account other = (Account)obj;
            return other.Number.Equals(Number);
        }
        public override string ToString()
        {
            return $"Balance: {string.Format("{0:0.00}", Balance)}";
        }

        public virtual void ChangeRate(decimal rate)
        {
            Console.WriteLine("This account don't contains RATE property...");
        }
    }
}
