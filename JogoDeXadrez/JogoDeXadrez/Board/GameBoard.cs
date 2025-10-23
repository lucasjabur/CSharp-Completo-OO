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

        public Piece PieceOnBoard(Position position) {
            return Pieces[position.Row, position.Column];
        }
        // Implementando uma sobrecarga (overload) para o método PieceOnBoard()

        public bool IsThereAnyPiece(Position position) {
            ValidatePosition(position);
            return PieceOnBoard(position) != null;
        }

        public void PlacePiece(Piece piece, Position position) {
            if (IsThereAnyPiece(position)) {
                throw new BoardException($"The position '[{position.Row}, {position.Column}]' is already taken by another piece!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
        // Com a implementação do método acima, quem é responsável por posicionar a peça no tabuleiro
        // é o próprio tabuleiro, o que significa que quando uma peça é criada, ela não aparece posicionada
        // logo de início. Portanto, o atributo de posição da peça deve ser iniciada com 'null'.

        public Piece RemovePiece(Position position) {
            if (PieceOnBoard(position) == null) {
                return null;
            }

            Piece auxiliarPiece = PieceOnBoard(position);
            auxiliarPiece.Position = null;
            Pieces[position.Row, position.Column] = null;
            
            return auxiliarPiece;
        }
        public bool IsPositionValid(Position position) {
            if (position.Row < 0 || position.Row >= NumberOfRows || position.Column < 0 || position.Column >= NumberOfColumns) {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position) {
            if (!IsPositionValid(position)) {
                throw new BoardException($"Invalid position '[{position.Row}, {position.Column}]'!" +
                    "The value for rows and columns must be between 0 and 7 for both!");
            }
        }
    }
}
