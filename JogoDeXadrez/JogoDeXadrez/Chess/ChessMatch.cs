using System;
using Board;

namespace Chess {
    class ChessMatch {
        public GameBoard MatchBoard { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch() {
            MatchBoard = new GameBoard(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MoveExecution(Position origin, Position destination) {
            Piece piece = MatchBoard.RemovePiece(origin);
            piece.NumberOfMovementeIncrementer();
            MatchBoard.RemovePiece(destination);
            Piece capturedPiece = MatchBoard.RemovePiece(destination);
            MatchBoard.PlacePiece(piece, destination);
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
            if (CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            } else {
                CurrentPlayer = Color.White;
            }
        }

        private void PlacePieces() {
            MatchBoard.PlacePiece(new Tower(Color.White, MatchBoard), new ChessBoardPosition('C', 1).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.White, MatchBoard), new ChessBoardPosition('C', 2).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.White, MatchBoard), new ChessBoardPosition('D', 2).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.White, MatchBoard), new ChessBoardPosition('E', 1).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.White, MatchBoard), new ChessBoardPosition('E', 2).ConvertPosition());
            MatchBoard.PlacePiece(new King(Color.White, MatchBoard), new ChessBoardPosition('D', 1).ConvertPosition());

            MatchBoard.PlacePiece(new Tower(Color.Black, MatchBoard), new ChessBoardPosition('C', 7).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.Black, MatchBoard), new ChessBoardPosition('C', 8).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.Black, MatchBoard), new ChessBoardPosition('D', 7).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.Black, MatchBoard), new ChessBoardPosition('E', 7).ConvertPosition());
            MatchBoard.PlacePiece(new Tower(Color.Black, MatchBoard), new ChessBoardPosition('E', 8).ConvertPosition());
            MatchBoard.PlacePiece(new King(Color.Black, MatchBoard), new ChessBoardPosition('D', 8).ConvertPosition());
        }
    }
}
