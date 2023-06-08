using hw2_31._05_;

// 1
Console.WriteLine("1---------------------------\n");

string str = "Hello World!";
Console.WriteLine(str);
str = Functions.ReversStr(str);
Console.WriteLine(str);

// 2
Console.WriteLine("2---------------------------\n");

int n = 13;
Functions.Syrakuz(n);

// 3
Console.WriteLine("3 ---------------------------\n");
string str2 = "I hAtE this sTupId shit";
Console.WriteLine(str2);
str2 = Functions.Filter(str2);
Console.WriteLine(str2);

// 4
Console.WriteLine("4 ---------------------------\n");

string rngsymbols = Functions.RandomSymbols();
Console.WriteLine(rngsymbols);

// 5
Console.WriteLine("5 ---------------------------\n");
int[] array = new int[10] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10 };
foreach(int i in array)
{
    Console.WriteLine(i);
}
Console.WriteLine("---------------------------\n");
Console.WriteLine(Functions.FindLostNum(array));

//6
Console.WriteLine("---------------------------\n");
Functions.StartLifeGame(); // --- START GAME --- 

// 8
Console.WriteLine("---------------------------\n");

string en1 = "Hello world!";
en1 = Functions.encryption(en1,1);
Console.WriteLine(en1);
en1 = Functions.decoding(en1,1);
Console.WriteLine(en1);