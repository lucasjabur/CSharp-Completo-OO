namespace Tabuleiro {
    class Piece {
        public Position Position {  get; set; }
        public Color Color { get; protected set; } // acessada por todas as classes, porém alterada apenas por ela mesmo e pelas suas subclasses
        public int NumberOfMovements { get; protected set; }
        public Board Board { get; protected set; }
    
        public Piece(Position position, Color color,  Board board) {
            Position = position;
            Color = color;
            Board = board;
            NumberOfMovements = 0; // a peça ao ser criada ainda não se moveu, por isso é iniciado com 0
        }
    }
}
