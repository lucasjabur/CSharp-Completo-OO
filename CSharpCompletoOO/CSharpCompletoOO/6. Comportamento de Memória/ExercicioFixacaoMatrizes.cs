using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {
    internal class ExercicioFixacaoMatrizes {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Fazer um programa para ler dois números inteiro M e N, e depois ler uma matriz
            // MxN contendo números inteiros podendo haver repetições. Em seguida, ler um número inteiro
            // X que pertence à matriz. Para cada ocorrência de X, mostrar os valores à esquerda, acima e abaixo de X,
            // quando houver, conforme exemplo.

            Console.Write("Entre com o número de linhas: ");
            int linhas = int.Parse(Console.ReadLine());

            Console.Write("Entre com o número de colunas: ");
            int colunas = int.Parse(Console.ReadLine());

            int[,] matriz = new int[linhas, colunas];

            for (int i = 0; i < linhas; i++) {
                for (int j = 0; j < colunas; j++) {
                    Console.Write($"Inserir elemento [{i},{j}]: ");
                    int elemento = int.Parse(Console.ReadLine());
                    matriz[i, j] = elemento;
                }
            }

            for (int i = 0; i < matriz.GetLength(0); i++) {
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write($"\t{matriz[i, j]}");
                }
                Console.WriteLine();
            }

            Console.Write("Entre com um valor pertencente à matriz: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < linhas; i++) {
                for (int j = 0; j < colunas; j++) {
                    if (num == matriz[i, j]) { // resolução retirada e aprendida de: https://github.com/acenelio/matrix2-csharp/blob/master/Course/Program.cs
                        Console.WriteLine("Posição " + i + "," + j + ":");
                        if (j > 0) {
                            Console.WriteLine("Left: " + matriz[i, j - 1]);
                        }
                        if (i > 0) {
                            Console.WriteLine("Up: " + matriz[i - 1, j]);
                        }
                        if (j < linhas - 1) {
                            Console.WriteLine("Right: " + matriz[i, j + 1]);
                        }
                        if (i < colunas - 1) {
                            Console.WriteLine("Down: " + matriz[i + 1, j]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
