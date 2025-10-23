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
                    Console.Clear();
                    Screen.PrintBoard(match.MatchBoard);

                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.ReceiveBoardPosition().ConvertPosition();

                    bool[,] possiblePositions = match.MatchBoard.PieceOnBoard(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.MatchBoard, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReceiveBoardPosition().ConvertPosition();

                    match.MoveExecution(origin, destination);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
