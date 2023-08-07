using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_bank_
{
    class DepositAccount : Account
    {
        private readonly string _number = Guid.NewGuid().ToString();

        public override string Number => _number;

        public decimal Rate { get; set; }
        public DepositAccount(IClientInfo client)
        {
            Client = client;

            Balance = 0;

            if (client is Client inner)
                inner.Accounts.Add(this);
        }

        public override string ToString()
        {
            return $"Balance: {string.Format("{0:0.00}", Balance)} Rate: {Rate}";
        }

        public override void ChangeRate(decimal rate)
        {
            Rate = rate;
        }
    }
}
