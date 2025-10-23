using System;
using Board;
using Chess;

namespace Board {
    class Screen {
        public static void PrintBoard(GameBoard board) {
            for (int i = 0; i < board.NumberOfRows; i++) {
                Console.Write(8 - i + " | ");
                for (int j = 0; j < board.NumberOfColumns; j++) {

                    // Deve-se acessar as peças para imprimi-las no tabuleiro
                    // Porém, a matriz de peças é privada, então deve criar um método público
                    // que irá retornar uma peça em uma determinada posição do tabuleiro
                    if (board.PieceOnBoard(i, j) == null) {
                        Console.Write("-   ");
                    } else {
                        PrintPiece(board.PieceOnBoard(i, j));
                        Console.Write("   ");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine("   _______________________________");
            Console.WriteLine("\n    A   B   C   D   E   F   G   H");
        }

        public static ChessBoardPosition ReceiveBoardPosition() {
            string completePosition = Console.ReadLine();
            char column = completePosition[0];
            int row = int.Parse(completePosition[1] + " ");
            return new ChessBoardPosition(column, row);
        }

        public static void PrintPiece(Piece piece) {
            if (piece.Color == Color.White) {
                Console.Write(piece);
            } else {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
