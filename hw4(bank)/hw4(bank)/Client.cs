using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_bank_
{
    class Client : IClientInfo
    {
        public string Name { get; }

        public string PhoneNumber { get; }

        public string INN { get; }

        public DateOnly BirthDate { get; }

        public HashSet<Account> Accounts { get; } = new HashSet<Account>();

        public Client(string name, string phoneNumber, DateOnly birthDate, string inn)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            INN = inn;
            Console.WriteLine(this);
        }
        public Client(string inn)
        {
            INN = inn;
        }

        public override int GetHashCode()
        {
            return INN.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Client)) return false;
            Client other = (Client)obj;
            return other.INN.Equals(INN);
        }

        public void ShowAccountsBalance()
        {
            int i = 1;
            foreach(var account in Accounts)
            {
                Console.WriteLine($"{i}. " + account.GetType().Name + "\n" + account.ToString());
                i++;
            }
        }


        public override string ToString()
        {
            return $"INN: {INN}, Name: {Name}";
        }
    }
}
