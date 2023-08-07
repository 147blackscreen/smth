using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_bank_
{
    interface IClientInfo
    {
        string Name { get; }
        string PhoneNumber { get; }
        string INN { get; }

        DateOnly BirthDate { get; }

        HashSet<Account> Accounts { get; }

        void ShowAccountsBalance();

        
    }

    interface IAccountInfo
    {
        string Number { get; }
        decimal Balance { get; }

        IClientInfo Client { get; }

        public TransitionHistory transitionHistory { get; }

        void Withdraw(decimal money);

        void Enrollment(decimal money);

        void ChangeRate(decimal rate);
    }
}
