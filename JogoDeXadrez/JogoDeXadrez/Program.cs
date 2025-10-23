using System;
using Board;
using Chess;

namespace JogoDeXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard(8, 8);

            board.PlacePiece(new Tower(Color.Black, board), new Position(0, 0));
            board.PlacePiece(new Tower(Color.Black, board), new Position(1, 3));
            board.PlacePiece(new King(Color.Black, board), new Position(2, 4));
            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
