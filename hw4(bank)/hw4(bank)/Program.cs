using hw4_bank_;

Console.WriteLine("-----BANK-----");
var bank = new Bank();
bank.CreateClient("a", "p", new DateOnly(2020, 9, 21),"1337");
bank.CreateAccount("1337");
bank.CreateAccount("1337");

bank.CreateClient("b", "r", new DateOnly(2020, 9, 21), "147");
bank.CreateAccount("147");
bank.CreateAccount("147");
bank.CreateAccount("147");

bank.MoneyManipulation("1337");
bank.MoneyManipulation("1337");

bank.ShowTransitionHistory("1337");

//bank.ShowAllCients();

