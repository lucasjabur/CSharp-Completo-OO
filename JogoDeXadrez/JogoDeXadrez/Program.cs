using System;
using Board;
using Chess;

namespace JogoDeXadrez
{
    internal class Program
    {
        static void Main(string[] args) {

            try {
                GameBoard board = new GameBoard(8, 8);

                board.PlacePiece(new Tower(Color.Black, board), new Position(0, 0));
                board.PlacePiece(new Tower(Color.Black, board), new Position(1, 6));
                board.PlacePiece(new King(Color.Black, board), new Position(0, 2));

                board.PlacePiece(new Tower(Color.White, board), new Position(0, 4));
                board.PlacePiece(new King(Color.White, board), new Position(2, 5));
                board.PlacePiece(new Tower(Color.White, board), new Position(4, 6));

                Screen.PrintBoard(board);

                Console.ReadLine();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            ChessBoardPosition boardPosition = new ChessBoardPosition('c', 7);
            Console.WriteLine(boardPosition);
            Console.WriteLine(boardPosition.ConvertPosition());
        }
    }
}
