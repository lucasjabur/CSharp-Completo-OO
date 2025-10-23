using System;
using Board;

namespace Chess {
    class Tower : Piece {

        public Tower(Color color, GameBoard board) : base(color, board) { }

        private bool CanBeMoved(Position pos) {
            Piece piece = Board.PieceOnBoard(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements() {
            bool[,] possibleMovements = new bool[Board.NumberOfRows, Board.NumberOfColumns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
                if (Board.PieceOnBoard(pos) != null && Board.PieceOnBoard(pos).Color != Color) {
                    break;
                }
                pos.Row = pos.Row - 1;
            }

            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
                if (Board.PieceOnBoard(pos) != null && Board.PieceOnBoard(pos).Color != Color) {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
                if (Board.PieceOnBoard(pos) != null && Board.PieceOnBoard(pos).Color != Color) {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
                if (Board.PieceOnBoard(pos) != null && Board.PieceOnBoard(pos).Color != Color) {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return possibleMovements;
        }

        public override string ToString() {
            return "T";
        }
    }
}
