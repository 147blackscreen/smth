using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hw2_31._05_
{
    public static class Functions
    {
        static int changes = 100;
        static int newlive = 0;
        static int newdead = 0;
        static string[] FilterWords;
        static Random rng = new Random();
        static int GeneratedKey;
        static int EnglishLettersCount = 26;
        static int fieldLen = 10;
        static int[,] field = new int[fieldLen, fieldLen];
        static int MaxCells = 6;
        static int[,] closeCoor = new int[8, 2] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 },{ 1, -1 }, { 0, -1 } };
        // 1
        static Functions()
        {
            FilterWords = new string[] { "hate", "shit", "stupid" };
        }
        public static string ReversStr(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "Empty string";

            char[] strarr = str.ToCharArray();
            return ReversStr(strarr);
        }
        public static string ReversStr(char[] str)
        {
            if (str == null)
                return "Empty array";

            char tmp;
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                tmp = str[i];
                str[i] = str[j];
                str[j] = tmp;
            }

            string res = new string(str);
            return res;
        }

        // 2

        public static void Syrakuz(int n)
        {
            Console.WriteLine(n);
            if (n == 1)
                return;

            if (n % 2 == 0)
                Syrakuz(n / 2);
            else
                Syrakuz((n * 3 + 1) / 2);
        }

        // 3

        private static string Replace(string str, string word)
        {
            string tmp = str.ToLower();
            int index = tmp.IndexOf(word);
            char[] charstr = str.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                charstr[index + i] = '*';
            }

            str = new string(charstr);
            return str;
        }
        public static string Filter(string str)
        {
            int index = 0;

            while (index != FilterWords.Length)
            {
                for (int i = index; i < FilterWords.Length; i++)
                {
                    if (str.ToLower().Contains(FilterWords[i]))
                    {
                        str = Replace(str, FilterWords[i]);
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return str;
        }

        // 4

        public static string RandomSymbols()
        {
            int size = rng.Next(3, 10);
            char[] symbols = new char[size];
            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = (char)rng.Next(0, 256);
            }

            string res = new string(symbols);
            return res;
        }

        // 5 
        public static int FindLostNum(int[] arr)
        {
            int CurrentSum = 0;
            int RequireSum = 0;
            int j = 1;
            foreach(int i in arr)
            {
                RequireSum += j;
                CurrentSum += i;
                j++;
            }
            return RequireSum - CurrentSum;
        }
        
        // 6

        private static void FillField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    field[i, j] = 0;
                }
            }
        }
        private static void ShowField()
        {
            // col nums
            Console.Write("    ");
            for (int i = 0; i < fieldLen; i++)
            {
                Console.Write($"| {i} ");
                if (i == fieldLen - 1)
                    Console.Write("|\n");
            }
            for (int i = 0; i < fieldLen; i++)
            {
                Console.Write($"| {i} ");
                for (int j = 0; j < fieldLen; j++)
                {
                    if (field[i,j] == 0)
                        Console.Write("|   ");
                    else
                    {
                        Console.Write($"| ");

                        if (field[i,j] == 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (field[i,j] == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write($"{field[i, j]} ");

                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if(j== fieldLen - 1)
                        Console.Write("|\n");
                }
            }
        }
        private static void SetCell()
        {
            int setCells = 0;
            int stCoor = 0;
            int ndCoor = 0;
            string tmp;
            while (setCells != MaxCells)
            {
                Console.Clear();
                ShowField();
                Console.WriteLine("Enter numbers to SET the CELL in selected position.(example. 9 3(MAX - 9, MIN - 0)");

                tmp = Console.ReadLine();
                stCoor = Convert.ToInt32(tmp);

                if (ndCoor < 0 || ndCoor > fieldLen - 1)
                {
                    Console.WriteLine("Wrong COORDINATES, enter again...");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("Second...");
                tmp = Console.ReadLine();
                ndCoor = Convert.ToInt32(tmp);

                if(stCoor < 0 || stCoor > fieldLen - 1)
                {
                    Console.WriteLine("Wrong COORDINATES, enter again...");
                    Thread.Sleep(2000);
                    continue;
                }

                if (field[stCoor,ndCoor] == 0)
                {
                    field[stCoor, ndCoor] = 2;
                    setCells++;
                }
                else
                {
                    Console.WriteLine("CELL already filled... enter again...");
                    Thread.Sleep(2000);
                }
            }
        }
        private static bool CheckEndGame()
        {
            if(changes==0) return false;
            for (int i = 0; i < fieldLen; i++)
            {
                for (int j = 0; j < fieldLen; j++)
                {
                    if (field[i,j] == 2)
                        return true;
                }
            }
            return false;
        }
        private static int CloseLiveCellsCount(int ic, int jc)
        {
            int tmpi = 0;
            int tmpj = 0;
            int liveCells = 0;
            for (int i = 0; i < 8; i++)
            {
                tmpi = closeCoor[i, 0] + ic;
                tmpj = closeCoor[i, 1] + jc;
                if (tmpi >= 0 && tmpi < fieldLen && tmpj >= 0 && tmpj < fieldLen)
                {
                    if (field[tmpi,tmpj] == 2 || field[tmpi,tmpj] == 3)
                        liveCells++;
                }
            }
            return liveCells;
        }
        private static void MakeStep()
        {
            for (int i = 0; i < fieldLen; i++)
            {
                for (int j = 0; j < fieldLen; j++)
                {
                    // if DEAD CELL have 3 LIVE CELLS it will turn ALIVE
                    if (field[i,j] == 0 || field[i,j] == 1)
                    {
                        if (CloseLiveCellsCount(i, j) == 3)
                            field[i, j] = 3;
                    }
                    else if (field[i,j] == 2)
                    {
                        int tmpc = CloseLiveCellsCount(i, j);
                        if (tmpc > 3 || tmpc < 2)
                            field[i,j] = 1;
                    }
                }
            }
        }
        private static void ClearDeadCells()
        {

            changes = 0;
            newdead = 0;
            newlive = 0;
            for (int i = 0; i < fieldLen; i++)
            {
                for (int j = 0; j < fieldLen; j++)
                {
                    if (field[i,j] == 1)
                    {
                        field[i, j] = 0;
                        changes++;
                        newdead++;
                    }

                    if (field[i, j] == 3)
                    {
                        field[i, j] = 2;
                        changes++;
                        newlive++;
                    }
                }
            }

        }
        private static void StartLife()
        {
            int Round = 1;
            while (CheckEndGame())
            {
                Console.Clear();
                Console.WriteLine($"\t\t--- Round {Round} ---\n");
                ShowField();
                Console.WriteLine("\t\t\t --- --- \n");
                if(Round!=1)
                    ClearDeadCells();

                MakeStep();
                Round++;
                Console.WriteLine($"New live/dead cells: {newlive} | {newdead}");
                Thread.Sleep(500);
            }

            Console.WriteLine($" \t\t--- GAME OVER ---\n" +
                $"\t\t--- YOU ALIVE {Round} Rounds ---");
        }
        public static void StartLifeGame()
        {
            FillField();
            SetCell();
            //field[3, 3] = 2;
            //field[3, 4] = 2;
            //field[4, 3] = 2;
            //field[2, 2] = 2;
            //field[5, 5] = 2;
            //field[6, 6] = 2;
            //field[7, 7] = 2;
            //field[8, 8] = 2;
            //field[5, 6] = 2;
            //field[1, 2] = 2;
            StartLife();
        }

        // 8
        private static int GenerateKey()
        {
            GeneratedKey = rng.Next(1, 100);
            return GeneratedKey;
        }
        public static string encryption(string str)
        {
            return encryption(str, GenerateKey());
        }

        public static string encryption(string str, int key)
        {
            key = key % 100;
            int fsl = 97;
            int lsl = 122;

            int fll = 65;
            int lll = 90;
            char[] charstr = str.ToCharArray();
            for (int i = 0; i < charstr.Length; i++)
            {
                if ((int)charstr[i] >= fsl && (int)charstr[i] <= lsl)
                {
                    charstr[i] = (char)(((int)charstr[i] - fsl + key) % EnglishLettersCount + fsl);
                }
                else if ((int)charstr[i] >= fll && (int)charstr[i] <= lll)
                {
                    charstr[i] = (char)(((int)charstr[i] - fll + key) % EnglishLettersCount + fll);
                }
                else
                {
                    charstr[i] = (char)(charstr[i] + key);
                }
            }
            str = new string(charstr);
            return str;
        }
        public static string decoding(string str, int key)
        {
            key = key % 100;
            int fsl = 97;
            int lsl = 122;

            int fll = 65;
            int lll = 90;
            char[] charstr = str.ToCharArray();
            for (int i = 0; i < charstr.Length; i++)
            {
                if ((int)charstr[i] >= fsl && (int)charstr[i] <= lsl)
                {
                    charstr[i] = (char)(((int)charstr[i] - fsl - key) % EnglishLettersCount + fsl);
                }
                else if ((int)charstr[i] >= fll && (int)charstr[i] <= lll)
                {
                    charstr[i] = (char)(((int)charstr[i] - fll - key) % EnglishLettersCount + fll);
                }
                else
                {
                    charstr[i] = (char)(charstr[i] - key);
                }
            }
            str = new string(charstr);
            return str;
        }
    }
}
