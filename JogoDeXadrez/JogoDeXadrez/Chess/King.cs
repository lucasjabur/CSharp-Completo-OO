using System;
using Board;

namespace Chess {
    class King : Piece {

        public King(PieceColor color, GameBoard board) : base(color, board) { }


        private bool CanBeMoved(Position pos) {
            Piece piece = Board.PieceOnBoard(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements() {
            bool[,] possibleMovements = new bool[Board.NumberOfRows, Board.NumberOfColumns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanBeMoved(pos)) {
                possibleMovements[pos.Row, pos.Column] = true;
            }

            return possibleMovements;
        }

        public override string ToString() {
            return "K";
        }
    }
}
