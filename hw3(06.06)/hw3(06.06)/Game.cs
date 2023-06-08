using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hw3_06._06_
{
    class Game
    {
        private Deck deck;
        private Player[] players;
        private bool game = true;

        public Game() {
            deck = new Deck();
            players = new Player[2] {new Player(), new Player("player")};
            deck.OutDeck();

            deck.Shuffle();
            deck.OutDeck();

            deck.Aces();
            deck.OutDeck();

            deck.SetSuitAtStart(Suits.Hearts);
            deck.OutDeck();

            deck.SortDeck();
            deck.OutDeck();

            // ------

            StartGame();
        }
        private void StartGame()
        {
            while (game)
            {
                int choice = ShowChoice();

                switch (choice)
                {
                    case 1:
                        StartRound();
                        break;
                    case 2:
                        Console.WriteLine("Exit...");
                        return;
                    case 3:
                        ShowStats();
                        break;
                }
            }
        }
        private void StartRound()
        {
            deck.Shuffle();
            GiveCards();
            ShowTable();
            if (CheckWinner())
                return;
            BringAdditionalCardOption();
            ShowTable();
            CheckRoundWinner();
        }
        private bool CheckWinner()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetPoints() == 21 || players[i].Cards[0].Rank == 14 && players[i].Cards[1].Rank == 14)
                {
                    SetStats(i);
                    ShowWinner(i);
                    return true;
                }
            }
            return false;
        }
        private void CheckRoundWinner()
        {
            int countbigger = 0;
            if (!CheckWinner())
            {
                foreach (Player player in players)
                {
                    if (player.GetPoints() > 21)
                        countbigger++;
                }

                if(countbigger == players.Length)
                {
                    int minPoints = players[0].GetPoints();
                    int minIndex = 0;
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].GetPoints() < minPoints)
                        {
                            minPoints = players[i].GetPoints();
                            minIndex = i;
                        }
                    }
                    SetStats(minIndex); 
                    ShowWinner(minIndex);
                    return;
                }
                else
                {
                    int minPoints = players[0].GetPoints();
                    int minIndex = 0;
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].GetPoints() > minPoints && players[i].GetPoints() < 21)
                        {
                            minPoints = players[i].GetPoints();
                            minIndex = i;
                        }
                    }
                    SetStats(minIndex);
                    ShowWinner(minIndex);
                    return;
                }
            }
        }
        private void SetStats(int player)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (i == player)
                    players[i].RoundWin();
                else
                    players[i].RoundLose();
            }
        }
        private void ShowWinner(int winner)
        {
            Player win = players[winner];
            Card[] winCards = win.Cards.ToArray();
            Console.WriteLine("\t--- --- --- --- ---");
            Console.WriteLine($"\t{win.Name} WINS with {win.GetPoints()} points!!!");
            Console.Write("\n\tCards: ");
            foreach (Card card in winCards)
            {
                Console.Write($"{deck.ToRankSymbol(card.Rank)} | ");
            }
            Console.WriteLine("\n\t--- --- --- --- ---");

            Console.ReadLine();

        }
        private void BringAdditionalCardOption()
        {
            foreach(Player player in players)
            {
                if(player.BringAdditionalCard())
                    player.AddCard(deck.GetNextCard());
            }
        }
        private void ShowStats()
        { // 1 7 = 
            Console.Clear();
            double wins = players[1].Wins;
            double loses = players[1].Loses;
            double winRate = wins / (wins + loses) * 100;
            Console.WriteLine("\n\t--- --- --- --- --- ---");
            Console.WriteLine($"\t === Wins: {players[1].Wins} and Loses: {players[1].Loses} ===");
            Console.WriteLine($"\t === === Winrate: {winRate}% === ===");
            Console.WriteLine("\t--- --- --- --- --- ---");
            Console.ReadLine();

        }
        private void GiveCards()
        {
            Console.WriteLine("Who will bring cards first?...");
            Console.WriteLine("0 -  you, 1 - BOT");
            int ch = Convert.ToInt32(Console.ReadLine());
            ch = ch % 2;
            players[ch].NewCards(deck.GetNextCard(), deck.GetNextCard());
            ch = (ch + 1) % 2;
            players[ch].NewCards(deck.GetNextCard(), deck.GetNextCard());
            Console.WriteLine("Take your cards...");
            Thread.Sleep(500);
        }
        private void ShowTable()
        {
            Console.Clear();
            for(int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"\n\t\t{players[i].Name}\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t   ");
                    foreach (Card c in players[i].Cards)
                    {
                        if (j == 0)
                            Console.Write(" ___ ");
                        else if (j == 1)
                            Console.Write($"|{deck.ToRankSymbol(c.Rank)} |");
                        else if (j == 2)
                            Console.Write($"|_{deck.ToSymbol(c.Suit)}_|");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\t--------------------") ;
            }
            Console.ReadLine();
        }
        private int ShowChoice()
        {
            Console.Clear();
            Console.WriteLine("1 - Continue Game");
            Console.WriteLine("2 - Exit");
            Console.WriteLine("3 - Show Stats");
            int ch = Convert.ToInt32(Console.ReadLine());
            return ch;
        }
    }
}
