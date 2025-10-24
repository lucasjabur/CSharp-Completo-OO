using System;
using Board;

namespace Chess {
    class King : Piece {

        private ChessMatch Match;
        public King(PieceColor color, GameBoard board, ChessMatch match) : base(color, board) {
            Match = match;
        }

        private bool CanBeMoved(Position pos) {
            Piece piece = Board.PieceOnBoard(pos);
            return piece == null || piece.Color != Color;
        }

        private bool RookTestForCastling(Position pos) {
            Piece piece = Board.PieceOnBoard(pos);
            return piece != null && piece is Rook && piece.Color == Color && piece.NumberOfMovements == 0;
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

            // Roque (Castling):
            if (NumberOfMovements == 0 && !Match.Check) {
                // Roque Pequeno (Kingside Castling):
                Position KCRookPosition = new Position(Position.Row, Position.Column + 3);
                if (RookTestForCastling(KCRookPosition)) {
                    Position firstPos = new Position(Position.Row, Position.Column + 1);
                    Position secondPos = new Position(Position.Row, Position.Column + 2);
                    if (Board.PieceOnBoard(firstPos) == null && Board.PieceOnBoard(secondPos) == null) {
                        possibleMovements[Position.Row, Position.Column + 2] = true;
                    }
                }

                // Roque Grande (Queenside Castling):
                Position QCRookPosition = new Position(Position.Row, Position.Column - 4);
                if (RookTestForCastling(QCRookPosition)) {
                    Position firstPos = new Position(Position.Row, Position.Column - 1);
                    Position secondPos = new Position(Position.Row, Position.Column - 2);
                    Position thirdPos = new Position(Position.Row, Position.Column - 3);
                    if (Board.PieceOnBoard(firstPos) == null && Board.PieceOnBoard(secondPos) == null && Board.PieceOnBoard(thirdPos) == null) {
                        possibleMovements[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMovements;
        }

        public override string ToString() {
            return "K";
        }
    }
}
