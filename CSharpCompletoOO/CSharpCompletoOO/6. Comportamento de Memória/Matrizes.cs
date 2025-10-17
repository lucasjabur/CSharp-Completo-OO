using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {
    internal class Matrizes {
        public static void MainX(string[] args) {
            // Instanciando uma matriz:

            double[,] matriz1 = new double[2, 3]; // 2 linhas e 3 colunas.
            Console.WriteLine(matriz1.Length); // número de elementos da matriz
            Console.WriteLine(matriz1.Rank); // quantidade de linhas da matriz
            Console.WriteLine(matriz1.GetLength(0)); // a dimensão 0 da matriz tem tamanho 2 (quantidade de linhas); dimensão da matriz [2, 3]
            Console.WriteLine(matriz1.GetLength(1)); // a dimensão 1 da matriz tem tamanho 3 (quantidade de colnas); dimensão da matriz [2, 3]
        }
    }
}
