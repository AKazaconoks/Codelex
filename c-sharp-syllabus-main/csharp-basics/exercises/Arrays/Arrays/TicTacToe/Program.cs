using System;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[3, 3];

        private static void Main(string[] args)
        {
            InitBoard();
            var move = 0;
            Console.WriteLine("Welcome to the game!");
            while (isGameNotOver() && move != 9)
            {
                Console.WriteLine(Move(move) + ", choose your location (row, column):");
                var play = Console.ReadLine();
                if (board[int.Parse(play[0].ToString()), int.Parse(play[2].ToString())].Equals(' '))
                {
                    board[int.Parse(play[0].ToString()), int.Parse(play[2].ToString())] = Move(move);
                    DisplayBoard();
                    move++;
                }
                else Console.WriteLine("You can't make this move. Please enter an empty cell");
            }
            if(move == 9) Console.WriteLine("The game is a tie");
            else Console.WriteLine("Game over! " + Move(--move) + " won!");
        }

        private static void InitBoard()
        {
            // fills up the board with blanks
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                    board[r, c] = ' ';
            }
            
        }

        private static void DisplayBoard()
        {
            Console.WriteLine("  0  " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  1  " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  2  " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            Console.WriteLine("    --+-+--");
        }

        private static bool isGameNotOver()
        {
            if (!board[0, 0].Equals(' ') && board[0, 0].Equals(board[0, 1]) && board[0, 0].Equals(board[0, 2]) ||
                !board[1, 0].Equals(' ') && board[1, 0].Equals(board[1, 1]) && board[1, 0].Equals(board[1, 2]) ||
                !board[2, 0].Equals(' ') && board[2, 0].Equals(board[2, 1]) && board[2, 0].Equals(board[2, 2]) ||
                !board[0, 0].Equals(' ') && board[0, 0].Equals(board[1, 1]) && board[0, 0].Equals(board[2, 2]) ||
                !board[0, 2].Equals(' ') &&  board[0, 2].Equals(board[1, 1]) && board[0, 2].Equals(board[2, 0]) ||
                !board[0, 0].Equals(' ') && board[0, 0].Equals(board[1, 0]) && board[0, 0].Equals(board[2, 0]) ||
                !board[0, 1].Equals(' ') &&  board[0, 1].Equals(board[1, 1]) && board[0, 1].Equals(board[2, 1]) ||
                !board[1, 2].Equals(' ') && board[0, 2].Equals(board[1, 2]) && board[0, 2].Equals(board[2, 2])) return false;
            return true;
        }

        private static char Move(int move)
        {
            return move % 2 == 0 ? 'X' : '0';
        }
    }
}
