using Board;
using System;


namespace Chess {
    class Pawn : Piece {

        private ChessMatch Match;

        public Pawn(PieceColor color, GameBoard board, ChessMatch match) : base(color, board) {
            Match = match;
        }

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

                // En Passant:
                if (Position.Row == 3) {
                    Position left  = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && ExistsEnemy(left) && Board.PieceOnBoard(left) == Match.VulnerableToEnPassant) {
                        possibleMovements[left.Row - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && ExistsEnemy(right) && Board.PieceOnBoard(right) == Match.VulnerableToEnPassant) {
                        possibleMovements[right.Row - 1, right.Column] = true;
                    }
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

                // En Passant:
                if (Position.Row == 4) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && ExistsEnemy(left) && Board.PieceOnBoard(left) == Match.VulnerableToEnPassant) {
                        possibleMovements[left.Row + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && ExistsEnemy(right) && Board.PieceOnBoard(right) == Match.VulnerableToEnPassant) {
                        possibleMovements[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return possibleMovements;
        }

        public override string ToString() {
            return "P";
        }
    }
}
