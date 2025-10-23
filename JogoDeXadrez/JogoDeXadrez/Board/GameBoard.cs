using System;

namespace Board {
    class GameBoard {
        public int NumberOfRows { get; set; }
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

        public Piece PieceOnBoard(Position pos) {
            return Pieces[pos.Row, pos.Column];
        }
        // Implementando uma sobrecarga (overload) para o método PieceOnBoard()

        public bool IsThereAnyPiece(Position pos) {
            ValidatePosition(pos);
            return PieceOnBoard(pos) != null;
        }

        public void PlacePiece(Piece piece, Position pos) {
            if (IsThereAnyPiece(pos)) {
                throw new BoardException($"The position '[{pos.Row}, {pos.Column}]' is already taken by another piece!");
            }
            Pieces[pos.Row, pos.Column] = piece;
            piece.Position = pos;
        }
        // Com a implementação do método acima, quem é responsável por posicionar a peça no tabuleiro
        // é o próprio tabuleiro, o que significa que quando uma peça é criada, ela não aparece posicionada
        // logo de início. Portanto, o atributo de posição da peça deve ser iniciada com 'null'.

        public Piece RemovePiece(Position pos) {
            if (PieceOnBoard(pos) == null) {
                return null;
            }

            Piece auxiliarPiece = PieceOnBoard(pos);
            auxiliarPiece.Position = null;
            Pieces[pos.Row, pos.Column] = null;
            
            return auxiliarPiece;
        }
        public bool IsPositionValid(Position pos) {
            if (pos.Row < 0 || pos.Row >= NumberOfRows || pos.Column < 0 || pos.Column >= NumberOfColumns) {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos) {
            if (!IsPositionValid(pos)) {
                throw new BoardException($"Invalid position '[{pos.Row}, {pos.Column}]'!" +
                    "The value for rows and columns must be between 0 and 7 for both!");
            }
        }
    }
}
