using System;

namespace Board {
    class Piece {
        public Position Position {  get; set; }
        public Color Color { get; protected set; } // acessada por todas as classes, porém alterada apenas por ela mesmo e pelas suas subclasses
        public int NumberOfMovements { get; protected set; }
        public GameBoard Board { get; protected set; }
    
        public Piece(Color color,  GameBoard board) {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMovements = 0; // a peça ao ser criada ainda não se moveu, por isso é iniciado com 0
        }
    }
}
