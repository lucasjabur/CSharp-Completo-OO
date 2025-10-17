using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {
    internal class ExercicioMatriz {
        public static void MainX(string[] args) {
            // Exercício:
            // Fazer um programa para ler um número inteiro N e uma matriz de ordem N (matriz quadrada NxN)
            // contendo números inteiros. Em seguida, mostrar a diagonal principal e a quantidade de valor
            // negativos da matriz.

            Console.Write("Entre com um valor inteiro: ");
            int valorN = int.Parse(Console.ReadLine());

            int[,] matriz = new int[valorN, valorN];
            for (int i = 0; i < matriz.GetLength(0); i++) { // 'matriz.Rank' --> número de linhas
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write($"Inserir elemento [{i},{j}]: ");
                    int valor = int.Parse(Console.ReadLine());
                    matriz[i, j] = valor;
                }
            }

            Console.WriteLine("\n\nMatriz completa:");
            for (int i = 0; i < matriz.GetLength(0); i++) { // 'matriz.Rank' --> número de linhas
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write($"\t{matriz[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\nDiagonal Principal:");
            for (int i = 0; i < matriz.GetLength(0); i++) {
                Console.Write($"\t{matriz[i, i]}");
            }

            Console.WriteLine("\n\nValores negativos na matriz: ");
            for (int i = 0; i < matriz.GetLength(0); i++) { // 'matriz.Rank' --> número de linhas
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    if (matriz[i,j] < 0 ) {
                        Console.Write($"\t{matriz[i, j]}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
