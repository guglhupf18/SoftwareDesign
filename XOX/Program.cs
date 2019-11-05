using System;

namespace XOX_Test02
{
    class Program
    {
        static void Main(string[] args)
        {
            generatePlayfield();
            printBoardAndTurn();

        }
        static string[] board;
        static int turn;
        static bool win = false;
        static void generatePlayfield()
        {
            turn = 1;
            board = new string[9];
            board[0] = "0";
            board[1] = "1";
            board[2] = "2";
            board[3] = "3";
            board[4] = "4";
            board[5] = "5";
            board[6] = "6";
            board[7] = "7";
            board[8] = "8";
            
        }

        static void printBoardAndTurn()
        {
            Console.WriteLine(board[0] + "" + board[1] + "" + board[2]);
            Console.WriteLine(board[3] + "" + board[4] + "" + board[5]);
            Console.WriteLine(board[6] + "" + board[7] + "" + board[8]);

            checkForWin();

            if (turn < 9 && !win)
                Console.WriteLine("Nächster Spieler ist am Zug. Wähle die gewünschte Position");

            else if (turn == 9 && !win)
                Console.WriteLine("Das Spiel endet unentschieden");

            if (win)
                Console.WriteLine("Das Spiel wurde gewonnen");


            while (!win)
            {   
                var input = Console.ReadLine();
                playerTurn(Int32.Parse(input));

            }

        }

        static void playerTurn(int position)
        {

            if (position < 9)
            {
                if (turn / 2 < 1)
                    board[position] = "X";
                else
                    board[position] = "O";
            }
            else
                Console.WriteLine("Die eingegebene Position ist ungültig");
            
            turn++;
            printBoardAndTurn();
            

        }
        static bool checkForWin()
        {
            if (board[0] == board[1] && board[0] == board[2])
                win = true;

            else if (board[3] == board[4] && board[3] == board[5])
                win = true;

            else if (board[6] == board[7] && board[6] == board[8])
                win = true;
            else if (board[0] == board[4] && board[0] == board[8])
                win = true;

            else if (board[2] == board[4] & board[2] == board[6])
                win = true;

            else
                win = false;

            return win;
        }

    }
}
