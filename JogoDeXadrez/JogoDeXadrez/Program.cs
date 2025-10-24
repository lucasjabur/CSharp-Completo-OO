using System;
using Board;
using Chess;

namespace JogoDeXadrez
{
    internal class Program
    {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();

                while (!match.Finished) {

                    try {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();

                        Console.Write("Origin: ");
                        Position origin = Screen.ReceiveBoardPosition().ConvertPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.MatchBoard.PieceOnBoard(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.MatchBoard, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReceiveBoardPosition().ConvertPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.DoPlay(origin, destination);

                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
