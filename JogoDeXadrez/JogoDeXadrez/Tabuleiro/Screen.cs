using Tabuleiro;

namespace Tabuleiro {
    class Screen {
        public static void PrintBoard(Board board) {
            for (int i = 0; i < board.NumberOfRows; i++) {
                for (int j = 0; j < board.NumberOfColumns; j++) {

                    // Deve-se acessar as peças para imprimi-las no tabuleiro
                    // Porém, a matriz de peças é privada, então deve criar um método público
                    // que irá retornar uma peça em uma determinada posição do tabuleiro
                    if (board.PieceOnBoard(i, j) == null) {
                        Console.Write("-  ");
                    } else {
                        Console.Write(board.PieceOnBoard(i, j) + "  ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
