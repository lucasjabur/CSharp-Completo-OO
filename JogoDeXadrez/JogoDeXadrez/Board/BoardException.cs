using System;
using Board;

namespace Board {
    class BoardException : Exception {
    
        public BoardException(string message) : base(message) { }
    }
}
