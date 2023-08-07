using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw4_bank_
{
    class Bank
    {
        private class ClientSearch : Client
        {
            public ClientSearch(string inn) : base(inn)
            {

            }
        }

        private class AccountSearch : Account
        {
            public override string Number { get; }

            public AccountSearch(string number)
            {
                Number = number;
            }
        }
        private HashSet<Client> _clients = new HashSet<Client>();
        private HashSet<Account> _accounts = new HashSet<Account>();

        public void CreateClient(string name, string phonenumber, DateOnly date, string inn)
        {
            if (GetClient(inn) == null)
                _clients.Add(new Client(name, phonenumber, date, inn));
        }
        public void CreateAccount(string inn)
        {
            var client = GetClient(inn) ?? throw new Exception("No Client found with this INN");
            
            _accounts.Add(new DepositAccount(client));
            //client.Accounts.Add(_accounts.Last());
            Console.WriteLine("\t ---\nCreate Client");
            client.ShowAccountsBalance();
            Console.WriteLine("\t ---");
        }
        public IClientInfo? GetClient(string inn)
        {
            var search = new ClientSearch(inn);
            if (!_clients.TryGetValue(search, out Client? client))
                return null;

            return client;
        }
        public IAccountInfo? GetAccount(string number)
        {
            var search = new AccountSearch(number);
            if(!_accounts.TryGetValue(search, out Account? account))
                return null;

            return account;
        }

        public void MoneyManipulation(string inn)
        {
            Console.WriteLine("<--- Money manipulation --->");

            if (inn == null) throw new Exception("Wrong inn");

            var acc = GetClient(inn);
            if (acc == null) throw new Exception("account not found");

            acc.ShowAccountsBalance();

            Console.WriteLine("<--- Choose account --->");
            var value = Console.ReadLine();

            if(int.TryParse(value, out int choice))
            {
                if(acc.Accounts.Count >= choice)
                {
                    var account = GetAccount(acc.Accounts.ElementAt(choice-1).Number);

                    Console.WriteLine(account);
                    if (account == null)
                        throw new Exception("Account not found");
                    MoneyChoiceText();
                    value = Console.ReadLine();

                    if(int.TryParse(value, out choice))
                    {
                        if (IsWrongChoice(choice))
                            throw new Exception("wrong choice");

                        Console.WriteLine("Enter amount of money");
                        value = Console.ReadLine();
                        if(decimal.TryParse(value, out decimal money))
                        {
                            switch (choice)
                            {
                                case 1: account.Withdraw(money); break;
                                case 2: account.Enrollment(money); break;
                            }
                        }
                    }
                    
                }
            }
            Console.WriteLine("<--- End --->");

            //Console.WriteLine($"\n---\n{acc}\n---");
        }

        private void MoneyChoiceText()
        {
            Console.WriteLine("\nChoose method...");
            Console.WriteLine("1. Withdraw\n2. Enrollment");
        }

        public void ShowAllCients()
        {
            int i = 1;
            int j = 1;
            foreach(var client in _clients)
            {
                Console.WriteLine("\n<------------->");

                Console.WriteLine($"{i}." + client);
                i++;

                foreach(var account in client.Accounts)
                {
                    Console.WriteLine($"{j}." + account);
                    j++;
                }
                j = 1;
            }
            Console.WriteLine("<------------->");

        }

        public void ChangeRate(string inn)
        {
            Console.WriteLine("<--- Change Rate --->");

            bool process = false;
            var client = GetClient(inn);
            if (client == null) throw new Exception("Account not found");

            while (!process)
            {
                client.ShowAccountsBalance();
                Console.WriteLine("Choose account...(0 - exit)");
                var ch = Console.ReadLine();
                int choice;
                if (int.TryParse(ch, out choice))
                {
                    if(choice == 0)
                    {
                        return;
                    }
                    if(choice > client.Accounts.Count || choice < 1)
                    {
                        Console.WriteLine("Wrong choice");
                        continue;
                    }

                    while(!process)
                    {
                        Console.WriteLine("Enter RATE value");
                        var val = Console.ReadLine();
                        decimal newRate;
                        if (decimal.TryParse(val, out newRate))
                        {
                            if (choice < 0)
                            {
                                Console.WriteLine("Wrong RATE value");
                                continue;
                            }
                            client.Accounts.ElementAt(choice - 1).ChangeRate(newRate);
                            process = true;
                            client.ShowAccountsBalance();
                        }
                    }
                    
                }
            }
        }

        public void ShowTransitionHistory(string inn)
        {
            var client = GetClient(inn);
            if (client == null) throw new Exception("Wrong inn");

            Console.WriteLine("<--- Transition History ---> ");
            client.ShowAccountsBalance();

            Console.WriteLine("Choose account...(0 - exit)");

            var ch = Console.ReadLine();

            if(int.TryParse(ch, out  int choice))
            {
                if (choice == 0) {
                    return;
                }
                if(choice < 1 || choice > client.Accounts.Count)
                {
                    throw new Exception("Out of index");
                }

                foreach(TransitionInfo info in client.Accounts.ElementAt(choice - 1).transitionHistory.transitions)
                {
                    Console.WriteLine(info);
                }
            }

            Console.WriteLine("<--- End ---> ");


        }

        private bool IsWrongChoice(int choice)
        {
            int[] choiceNums = new int[]{ 1, 2 };
            foreach(int num in choiceNums)
            {
                if (choice == num)
                    return false;
            }
            return true;
        }
    }
}
