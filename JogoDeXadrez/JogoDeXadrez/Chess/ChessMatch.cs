using Board;
using System;
using System.Drawing;

namespace Chess {
    class ChessMatch {
        public GameBoard MatchBoard { get; private set; }
        public int Round { get; private set; }
        public PieceColor CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch() {
            MatchBoard = new GameBoard(8, 8);
            Round = 1;
            CurrentPlayer = PieceColor.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public void MoveExecution(Position origin, Position destination) {
            Piece piece = MatchBoard.RemovePiece(origin);
            piece.NumberOfMovementsIncrementer();
            Piece capturedPiece = MatchBoard.RemovePiece(destination);
            MatchBoard.PlacePiece(piece, destination);
            if (capturedPiece != null) {
                CapturedPieces.Add(capturedPiece);
            }
        }

        public void DoPlay(Position origin, Position destination) {
            MoveExecution(origin, destination);
            Round++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos) {
            if (MatchBoard.PieceOnBoard(pos) == null) {
                throw new BoardException($"There is no piece on the position '[{pos.Row}, {pos.Column}]'!");
            }
            if (CurrentPlayer != MatchBoard.PieceOnBoard(pos).Color) {
                throw new BoardException($"The piece chosen is not of color '{CurrentPlayer}'!");
            }
            if (!MatchBoard.PieceOnBoard(pos).IsTherePossibleMovements()) {
                throw new BoardException($"There is no possible movements for the chosen piece at position '[{pos.Row}, {pos.Column}]'");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination) {
            if (!MatchBoard.PieceOnBoard(origin).CanBeMovedTo(destination)) {
                throw new BoardException($"Invalid destination '[{origin.Row}, {origin.Column}]' to '[{destination.Row}, {destination.Column}]'!");
            }
        }

        private void ChangePlayer() {
            if (CurrentPlayer == PieceColor.White) {
                CurrentPlayer = PieceColor.Black;
            } else {
                CurrentPlayer = PieceColor.White;
            }
        }

        public HashSet<Piece> CapturedPiecesByColor(PieceColor color) {
            HashSet<Piece> auxiliarSet = new HashSet<Piece>();
            foreach(Piece piece in CapturedPieces) {
                if (piece.Color == color) {
                    auxiliarSet.Add(piece);
                }
            }
            return auxiliarSet;
        }

        public HashSet<Piece> InGamePiecesByColor(PieceColor color) {
            HashSet<Piece> auxiliarSet = new HashSet<Piece>();
            foreach (Piece piece in Pieces) {
                if (piece.Color == color) {
                    auxiliarSet.Add(piece);
                }
            }
            auxiliarSet.ExceptWith(CapturedPiecesByColor(color));
            return auxiliarSet;
        }

        public void PlaceNewPiece(char column, int row, Piece piece) {
            MatchBoard.PlacePiece(piece, new ChessBoardPosition(column, row).ConvertPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces() {
            PlaceNewPiece('C', 1, new Tower(PieceColor.White, MatchBoard));
            PlaceNewPiece('C', 2, new Tower(PieceColor.White, MatchBoard));
            PlaceNewPiece('D', 2, new Tower(PieceColor.White, MatchBoard));
            PlaceNewPiece('E', 1, new Tower(PieceColor.White, MatchBoard));
            PlaceNewPiece('E', 2, new Tower(PieceColor.White, MatchBoard));
            PlaceNewPiece('D', 1, new King(PieceColor.White, MatchBoard));

            PlaceNewPiece('C', 7, new Tower(PieceColor.Black, MatchBoard));
            PlaceNewPiece('C', 8, new Tower(PieceColor.Black, MatchBoard));
            PlaceNewPiece('D', 7, new Tower(PieceColor.Black, MatchBoard));
            PlaceNewPiece('E', 7, new Tower(PieceColor.Black, MatchBoard));
            PlaceNewPiece('E', 8, new Tower(PieceColor.Black, MatchBoard));
            PlaceNewPiece('D', 8, new King(PieceColor.Black, MatchBoard));
        }
    }
}
