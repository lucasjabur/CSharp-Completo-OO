using System;
using Board;

namespace Chess {
    class King : Piece {

        public King(Color color, GameBoard board) : base(color, board) { }

        public override string ToString() {
            return "R";
        }
    }
}
