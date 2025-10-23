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
                        Screen.PrintBoard(match.MatchBoard);
                        Console.WriteLine();
                        Console.WriteLine($"Round: {match.Round}");
                        Console.WriteLine($"Waiting for action: {match.CurrentPlayer}");

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
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
