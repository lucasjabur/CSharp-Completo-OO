using System;
using Board;

namespace Chess {
    class Tower : Piece {

        public Tower(Color color, GameBoard board) : base(color, board) { }

        public override string ToString() {
            return "T";
        }
    }
}
