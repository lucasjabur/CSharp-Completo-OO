﻿using Tabuleiro;

namespace JogoDeXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Console.WriteLine(board);
        }
    }
}
