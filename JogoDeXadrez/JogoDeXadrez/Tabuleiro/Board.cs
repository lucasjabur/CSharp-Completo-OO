namespace Tabuleiro {
    class Board {
        public int NumberOfRows {  get; set; }
        public int NumberOfColumns { get; set; }
        private Piece[,] Pieces;

        public Board(int numberOfRows, int numberOfColumns) {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            Pieces = new Piece[numberOfRows, numberOfColumns];
        }

        public Piece PieceOnBoard(int row, int column) {
            return Pieces[row, column];
        }

    }
}
