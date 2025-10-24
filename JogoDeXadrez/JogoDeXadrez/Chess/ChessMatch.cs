using Board;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Chess {
    class ChessMatch {
        public GameBoard MatchBoard { get; private set; }
        public int Round { get; private set; }
        public PieceColor CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool Check {  get; private set; }
        public Piece VulnerableToEnPassant { get; private set; }

        public ChessMatch() {
            MatchBoard = new GameBoard(8, 8);
            Round = 1;
            CurrentPlayer = PieceColor.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Check = false;
            VulnerableToEnPassant = null;
            PlacePieces();
        }

        public Piece MoveExecution(Position origin, Position destination) {
            Piece piece = MatchBoard.RemovePiece(origin);
            piece.NumberOfMovementsIncrementer();
            Piece capturedPiece = MatchBoard.RemovePiece(destination);
            MatchBoard.PlacePiece(piece, destination);
            if (capturedPiece != null) {
                CapturedPieces.Add(capturedPiece);
            }

            // Roque pequeno (Kingside Castling):
            if (piece is King && destination.Column == origin.Column + 2 ) {
                Position rookOrigin = new Position(origin.Row, origin.Column + 3);
                Position rookDestination = new Position(origin.Row, origin.Column + 1);
                Piece rook = MatchBoard.RemovePiece(rookOrigin);
                rook.NumberOfMovementsIncrementer();
                MatchBoard.PlacePiece(rook, rookDestination);
            }

            // Roque grande (Queenside Castling):
            if (piece is King && destination.Column == origin.Column - 2) {
                Position rookOrigin = new Position(origin.Row, origin.Column - 4);
                Position rookDestination = new Position(origin.Row, origin.Column - 1);
                Piece rook = MatchBoard.RemovePiece(rookOrigin);
                rook.NumberOfMovementsIncrementer();
                MatchBoard.PlacePiece(rook, rookDestination);
            }

            // En Passant:
            if (piece is Pawn) {
                if (origin.Column != destination.Column && capturedPiece == null) {
                    Position pawnPos;
                    if (piece.Color == PieceColor.White) {
                        pawnPos = new Position(destination.Row + 1, destination.Column);

                    } else {
                        pawnPos = new Position(destination.Row - 1, destination.Column);
                    }
                    capturedPiece = MatchBoard.RemovePiece(pawnPos);
                    CapturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoPlay(Position origin, Position destination, Piece capturedPiece) {
            Piece piece = MatchBoard.RemovePiece(destination);
            piece.NumberOfMovementsDecrementer();
            if (capturedPiece != null) {
                MatchBoard.PlacePiece(capturedPiece, destination);
                CapturedPieces.Remove(capturedPiece);
            }
            MatchBoard.PlacePiece(piece, origin);

            // Roque pequeno (Kingside Castling):
            if (piece is King && destination.Column == origin.Column + 2) {
                Position rookOrigin = new Position(origin.Row, origin.Column + 3);
                Position rookDestination = new Position(origin.Row, origin.Column + 1);
                Piece rook = MatchBoard.RemovePiece(rookDestination);
                rook.NumberOfMovementsIncrementer();
                MatchBoard.PlacePiece(rook, rookOrigin);
            }

            // Roque grande (Queenside Castling):
            if (piece is King && destination.Column == origin.Column - 2) {
                Position rookOrigin = new Position(origin.Row, origin.Column - 4);
                Position rookDestination = new Position(origin.Row, origin.Column - 1);
                Piece rook = MatchBoard.RemovePiece(rookDestination);
                rook.NumberOfMovementsIncrementer();
                MatchBoard.PlacePiece(rook, rookOrigin);
            }

            // En Passant:
            if (piece is Pawn) {
                if (origin.Column != destination.Column && capturedPiece == VulnerableToEnPassant) {
                    Piece pawn = MatchBoard.RemovePiece(destination);
                    Position pawnPos;
                    if (piece.Color == PieceColor.White) {
                        pawnPos = new Position(3, destination.Column);
                    
                    } else {
                        pawnPos = new Position(4, destination.Column);
                    }
                    MatchBoard.PlacePiece(pawn, pawnPos);
                }
            }
        }

        public void DoPlay(Position origin, Position destination) {
            Piece capturedPiece = MoveExecution(origin, destination);

            if (IsItCheck(CurrentPlayer)) {
                UndoPlay(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself on a check situation!");
            }

            if (IsItCheck(Oponent(CurrentPlayer))) {
                Check = true;
            } else {
                Check = false;
            }
            if (IsItCheckmate(Oponent(CurrentPlayer))) {
                Finished = true;
                
            } else {
                Round++;
                ChangePlayer();
            }

            Piece piece = MatchBoard.PieceOnBoard(destination);
            
            // En Passant:
            if (piece is Pawn && (destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2)) {
                VulnerableToEnPassant = piece;

            } else {
                VulnerableToEnPassant = null;
            }
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
            if (!MatchBoard.PieceOnBoard(origin).PossibleMovement(destination)) {
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

        private PieceColor Oponent(PieceColor color) {
            if (color == PieceColor.White) {
                return PieceColor.Black;
            } else {
                return PieceColor.White;
            }

        }

        private Piece King(PieceColor color) {
            foreach (Piece piece in InGamePiecesByColor(color)) {
                if (piece is King) {
                    return piece;
                }
            }
            return null;
        }

        private bool IsItCheck(PieceColor color) {
            Piece king = King(color);
            if (king == null) {
                throw new BoardException($"There is no King of color {color} on the board!");
            }

            foreach (Piece piece in InGamePiecesByColor(Oponent(color))) {
                bool[,] auxiliarPossibleMovements = piece.PossibleMovements();
                if (auxiliarPossibleMovements[king.Position.Row, king.Position.Column]) {
                    return true;
                }
            }
            return false;
        }

        public bool IsItCheckmate(PieceColor color) {
            if (!IsItCheck(color)) {
                return false;
            }
            foreach (Piece piece in InGamePiecesByColor(color)) {
                bool[,] auxiliarPossibleMovements = piece.PossibleMovements();
                for (int i = 0; i < MatchBoard.NumberOfRows; i++) {
                    for (int j = 0; j < MatchBoard.NumberOfColumns; j++) {
                        if (auxiliarPossibleMovements[i, j]) {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MoveExecution(origin, destination);
                            bool checkTest = IsItCheck(color);
                            UndoPlay(origin, destination, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece) {
            MatchBoard.PlacePiece(piece, new ChessBoardPosition(column, row).ConvertPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces() {
            
            PlaceNewPiece('A', 1, new Rook(PieceColor.White, MatchBoard));
            PlaceNewPiece('B', 1, new Knight(PieceColor.White, MatchBoard));
            PlaceNewPiece('C', 1, new Bishop(PieceColor.White, MatchBoard));
            PlaceNewPiece('D', 1, new Queen(PieceColor.White, MatchBoard));
            PlaceNewPiece('E', 1, new King(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('F', 1, new Bishop(PieceColor.White, MatchBoard));
            PlaceNewPiece('G', 1, new Knight(PieceColor.White, MatchBoard));
            PlaceNewPiece('H', 1, new Rook(PieceColor.White, MatchBoard));
            PlaceNewPiece('A', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('B', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('C', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('D', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('E', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('F', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('G', 2, new Pawn(PieceColor.White, MatchBoard, this));
            PlaceNewPiece('H', 2, new Pawn(PieceColor.White, MatchBoard, this));

            PlaceNewPiece('A', 8, new Rook(PieceColor.Black, MatchBoard));
            PlaceNewPiece('B', 8, new Knight(PieceColor.Black, MatchBoard));
            PlaceNewPiece('C', 8, new Bishop(PieceColor.Black, MatchBoard));
            PlaceNewPiece('D', 8, new Queen(PieceColor.Black, MatchBoard));
            PlaceNewPiece('E', 8, new King(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('F', 8, new Bishop(PieceColor.Black, MatchBoard));
            PlaceNewPiece('G', 8, new Knight(PieceColor.Black, MatchBoard));
            PlaceNewPiece('H', 8, new Rook(PieceColor.Black, MatchBoard));
            PlaceNewPiece('A', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('B', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('C', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('D', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('E', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('F', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('G', 7, new Pawn(PieceColor.Black, MatchBoard, this));
            PlaceNewPiece('H', 7, new Pawn(PieceColor.Black, MatchBoard, this));

        }
    }
}
