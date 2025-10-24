using System;

namespace Board {
    abstract class Piece {
        public Position Position {  get; set; }
        public PieceColor Color { get; protected set; } // acessada por todas as classes, porém alterada apenas por ela mesmo e pelas suas subclasses
        public int NumberOfMovements { get; protected set; }
        public GameBoard Board { get; protected set; }
    
        public Piece(PieceColor color,  GameBoard board) {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMovements = 0; // a peça ao ser criada ainda não se moveu, por isso é iniciado com 0
        }

        public void NumberOfMovementsIncrementer() {
            NumberOfMovements++;
        }

        public void NumberOfMovementsDecrementer() {
            NumberOfMovements--;
        }

        public bool IsTherePossibleMovements() {
            bool[,] possibleMovements = PossibleMovements();
            for (int i = 0; i < Board.NumberOfRows; i++) {
                for (int j = 0; j < Board.NumberOfColumns; j++) {
                    if (possibleMovements[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanBeMovedTo(Position pos) {
            return PossibleMovements()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
