using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Classes
{
    public class TicTacToe
    {
        private char[,] board;
        private Player humanPlayer;
        private ComputerPlayer computerPlayer;
        private char currentPlayer;

        public TicTacToe()
        {
            board = new char[3, 3];
            humanPlayer = new Player('X');
            computerPlayer = new ComputerPlayer('O');
            currentPlayer = humanPlayer.Symbol;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void PlayGame()
        {
            while (!IsGameOver())
            {
                DisplayBoard();
                MakeMove();
                SwitchPlayer();
            }

            DisplayResult();
        }

        private void DisplayBoard()
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void MakeMove()
        {
            if (currentPlayer == humanPlayer.Symbol)
            {
                humanPlayer.MakeMove(board);
            }
            else
            {
                computerPlayer.MakeMove(board);
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == humanPlayer.Symbol) ? computerPlayer.Symbol : humanPlayer.Symbol;
        }

        private bool IsGameOver()
        {
            return true;
        }

        private void DisplayResult()
        {
           throw new NotImplementedException();
        }
    }
}
