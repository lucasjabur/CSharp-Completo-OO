using Board;
using System;


namespace Chess {
    class Pawn : Piece {

        public Pawn(PieceColor color, GameBoard board) : base(color, board) { }
        
        private bool ExistsEnemy(Position pos) {
            Piece piece = Board.PieceOnBoard(pos);
            return piece != null && piece.Color != Color;
        }

        private bool PositionIsFree(Position pos) {
            return Board.PieceOnBoard(pos) == null;
        }

        public override bool[,] PossibleMovements() {
            bool[,] possibleMovements = new bool[Board.NumberOfRows, Board.NumberOfColumns];

            Position pos = new Position(0, 0);

            if (Color == PieceColor.White) {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(pos) && PositionIsFree(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 2, Position.Column);
                if (Board.IsPositionValid(pos) && PositionIsFree(pos) && NumberOfMovements == 0) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && ExistsEnemy(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && ExistsEnemy(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }
            } else {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(pos) && PositionIsFree(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 2, Position.Column);
                if (Board.IsPositionValid(pos) && PositionIsFree(pos) && NumberOfMovements == 0) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && ExistsEnemy(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && ExistsEnemy(pos)) {
                    possibleMovements[pos.Row, pos.Column] = true;
                }
            }

                return possibleMovements;
        }

        public override string ToString() {
            return "P";
        }
    }
}
