using System;
using Board;
using Chess;

namespace JogoDeXadrez {
    class Screen {

        public static void PrintMatch(ChessMatch match) {
            PrintBoard(match.MatchBoard);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"\nRound: {match.Round}");
            if (!match.Finished) {
                Console.WriteLine($"Waiting for action: {match.CurrentPlayer}");
                if (match.Check) {
                    Console.WriteLine("\n -- CHECK! --");
                }
            } else {
                Console.WriteLine("\n -- CHECKMATE! --");
                Console.WriteLine($"WINNER: {match.CurrentPlayer}");
            }
        }
        public static void PrintBoard(GameBoard board) {
            for (int i = 0; i < board.NumberOfRows; i++) {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < board.NumberOfColumns; j++) {                   
                    PrintPiece(board.PieceOnBoard(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine(" __________________");
            Console.WriteLine("   A B C D E F G H");
        }

        public static void PrintCapturedPieces(ChessMatch match) {
            Console.WriteLine("Captured pieces: ");
            
            Console.Write("White pieces: ");
            PrintSet(match.CapturedPiecesByColor(PieceColor.White));

            Console.WriteLine();

            Console.Write("Black pieces: ");
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPiecesByColor(PieceColor.Black));

            Console.ForegroundColor = defaultForegroundColor;
        }

        public static void PrintSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece piece in set) {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(GameBoard board, bool[,] possiblePositions) {

            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.NumberOfRows; i++) {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < board.NumberOfColumns; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = newBackground;
                    } else {
                        Console.BackgroundColor = defaultBackground;
                    }
                    PrintPiece(board.PieceOnBoard(i, j));
                    Console.BackgroundColor = defaultBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine(" __________________");
            Console.WriteLine("   A B C D E F G H");
            Console.BackgroundColor = defaultBackground;
        }

        public static ChessBoardPosition ReceiveBoardPosition() {
            string completePosition = Console.ReadLine();
            char column = completePosition[0];
            int row = int.Parse(completePosition[1] + " ");
            return new ChessBoardPosition(column, row);
        }

        public static void PrintPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            } else {
                if (piece.Color == PieceColor.White) {
                    Console.Write(piece);
                } else {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }
    }
}
