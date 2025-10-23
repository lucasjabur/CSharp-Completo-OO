using System;
using Board;

namespace Chess {
    class ChessBoardPosition {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessBoardPosition(char column, int row) {
            Column = char.ToUpper(column);
            Row = row;
        }

        public Position ConvertPosition() {
            return new Position(8 - Row, Column - 'A');
        }

        public override string ToString() {
            return "" + Column + Row;
        }
    }
}
