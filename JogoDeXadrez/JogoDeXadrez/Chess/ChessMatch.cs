using System;
using Board;

namespace Chess {
    class ChessMatch {
        public GameBoard MatchBoard { get; private set; }
        private int Round;
        private Color CurrentPlayer;
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
