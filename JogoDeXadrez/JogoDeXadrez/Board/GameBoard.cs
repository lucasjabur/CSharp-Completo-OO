using System;

namespace Board {
    class GameBoard {
        public int NumberOfRows {  get; set; }
        public int NumberOfColumns { get; set; }
        private Piece[,] Pieces;

        public GameBoard(int numberOfRows, int numberOfColumns) {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            Pieces = new Piece[numberOfRows, numberOfColumns];
        }

        public Piece PieceOnBoard(int row, int column) {
            return Pieces[row, column];
        }

        public void PlacePiece(Piece piece, Position position) {
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
        // Com a implementação do método acima, quem é responsável por posicionar a peça no tabuleiro
        // é o próprio tabuleiro, o que significa que quando uma peça é criada, ela não aparece posicionada
        // logo de início. Portanto, o atributo de posição da peça deve ser iniciada com 'null'.
    }
}
